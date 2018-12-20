﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using AppDevUnited.CannonGame.App.GameElements;
using Java.Lang;
using static Android.Views.SystemUiFlags;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using JavaObj = Java.Lang.Object;
using RawRes = AppDevUnited.CannonGame.App.Resource.Raw;
using ColorRes = AppDevUnited.CannonGame.App.Resource.Color;
using DialogFragment = Android.Support.V4.App.DialogFragment;
using Math = System.Math;
using StringRes = AppDevUnited.CannonGame.App.Resource.String;

namespace AppDevUnited.CannonGame.App
{
   /// <summary>
   ///    Класс отображает игровые объекты и управляет приложением Cannon Game
   /// </summary>
   public sealed class CannonView : SurfaceView
   {
      private const string ErrorTag = nameof(CannonView);

      /* TODO: Лучше сделать перечисления */

      // Игровые константы 
      private const int MissPenalty = 2; // Штраф при промахе
      private const int HitReward = 3; // Прибавка при попадании

      // Константы для рисования пушки
      private const double CannonBaseRadiusPercent = 0.075D;
      private const double CannonBarrelWidthPercent = 0.075D;
      private const double CannonBarrelLengthPercent = 0.1D;

      // Константы для рисования ядра
      internal const double CannonBallSpeedPercent = 1.5D;

      // Константы для рисования мишеней
      private const double TargetWidthPercent = 0.025D;
      private const double TargetLengthPercent = 0.15D;
      private const double TargetFirstXPercent = 0.6D;
      private const double TargetSpacingPercent = 0.0166666666666667D;
      private const double TargetPieces = 9.0D;
      private const double TargetMinSpeedPercent = 0.75D;
      private const double TargetMaxSpeedPercent = 1.5D;

      // Константы для рисования блока
      private const double BlockerWidthPercent = 0.025D;
      private const double BlockerLengthPercent = 0.25D;
      private const double BlockerXPercent = 0.5D;
      private const double BlockerSpeedPercent = 1.0D;

      // Размер текста составляет 1/18 ширины экрана
      private const double TextSizePercent = 0.0555555555555556D;

      // Константы и переменные для управления звуком
      public const int BlockerSoundId = 2;
      public const int TargetSoundId = 0;
      public const int CannonSoundId = 1;
      private const string ResultsTag = "results";

      private static readonly Func<bool> _MoreOrEqualThanKitKatFunc =
         () => Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat;

      private readonly AppCompatActivity _activity; // Для отображения окна в потоке GUI
      private readonly Paint _backgroundPaint; // Для стирания области рисования
      private readonly SparseIntArray _soundMap; // Связь идентификаторов с SoundPool

      private readonly SoundPool _soundPool; // Воспроизведение звуков

      // Переменные Paint для рисования элементов на экране
      private readonly Paint _textPaint; // Для вывода текста
      private Blocker _blocker;

      // Игровые объекты
      private Cannon _cannon;

      private CannonThread _cannonThread; // Управляет циклом игры
      private bool _dialogIsDisplayed;      

      // Переменные для игрового цикла и отслеживания состояния игры
      private bool _gameOver; // Игра закончена
      private int _shotsFired; // Кол-во сделанных выстрелов
      private List<Target> _targets;
      private double _timeLeft; // Оставшееся время в секундах
      private double _totalElapsedTime; // Затраты времени в секундах

      public CannonView(Context context, IAttributeSet attrs)
         : base(context, attrs)
      {
         _activity = (AppCompatActivity) context; // Ссылка на MainActivity
         Holder.AddCallback(new SurfaceHolderCallbackImpl(this)); // Регистрация слушателя         

         // Инициализация SoundPool для воспроизведения звука
         _soundPool = new SoundPool.Builder()
            .SetMaxStreams(1)
            .SetAudioAttributes(
               new AudioAttributes.Builder()
                  .SetUsage(AudioUsageKind.Game)
                  .Build())
            .Build();

         // Создание Map и предварительная загрузка звуков
         _soundMap = new SparseIntArray(3);
         _soundMap.Put(TargetSoundId,
            _soundPool.Load(context, RawRes.target_hit, 1));
         _soundMap.Put(CannonSoundId,
            _soundPool.Load(context, RawRes.cannon_fire, 1));
         _soundMap.Put(BlockerSoundId,
            _soundPool.Load(context, RawRes.blocker_hit, 1));

         _textPaint = new Paint();
         _backgroundPaint = new Paint {Color = Color.White};
      }

      /// <summary>
      ///    Получение ширины экрана
      /// </summary>
      private int ScreenWidth { get; set; }

      /// <summary>
      ///    Получение высоты экрана
      /// </summary>
      private int ScreenHeight { get; set; }

      protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
      {
         base.OnSizeChanged(w, h, oldw, oldh);

         ScreenWidth = w; // Сохранение ширины CannonView
         ScreenHeight = h; // Сохранение высоты CannonView

         // Настройка свойств текста
         _textPaint.TextSize = (int) (TextSizePercent * ScreenHeight);
         _textPaint.AntiAlias = true; // Сглаживание текста
      }

      public override bool OnTouchEvent(MotionEvent e)
      {
         var action = e.Action;

         // Пользователь коснулся экрана или провел пальцем по экрану
         if (action == MotionEventActions.Down || action == MotionEventActions.Move)
            AlignAndFireCannonBall(
               e); // Выстрел в направлении точки касания NOTE: В метод можно передавать меньше информации

         return true;
      }

      /// <summary>
      ///    Остановка игры
      /// </summary>
      internal void StopGame() => _cannonThread?.SetRunning(false);

      /// <summary>
      ///    Освобождение ресурсов
      /// </summary>
      public void ReleaseResources() => _soundPool?.Release();

      public void PlaySound(int soundId) => _soundPool.Play(_soundMap.Get(soundId), 1, 1, 1, 0, 1F);

      /// <summary>
      ///    Сброс всех экранных элементов
      /// </summary>
      private void NewGame()
      {
         // Создание новой пушки
         _cannon = new Cannon(this,
            (int) (CannonBaseRadiusPercent * ScreenWidth),
            (int) (CannonBarrelLengthPercent * ScreenWidth),
            (int) (CannonBarrelWidthPercent * ScreenHeight));

         var random = new Random(); // Для случайных скоростей
         _targets = new List<Target>(); // Построение нового списка мишеней NOTE: Лишнее создание объектов

         // Инициализация targetX для первой мишени слева
         var targetX = (int) (TargetFirstXPercent * ScreenWidth);

         // Вычисление координаты Y
         var targetY = (int) ((0.5 - TargetLengthPercent / 2) * ScreenHeight);

         // Добавление TargetPieces мишеней в список
         for (var n = 0; n < TargetPieces; n++)
         {
            // Получение случайной скорости в диапазоне от min до max для мишени n
            var velocity = ScreenHeight * (random.NextDouble() * (TargetMaxSpeedPercent - TargetMinSpeedPercent) +
                                           TargetMinSpeedPercent);

            // Цвета мишеней чередуются между белым и чёрным
            var color = Resources.GetColor(n % 2 == 0 ? ColorRes.dark : ColorRes.light, Context.Theme);
            velocity *= -1; // Противоположная скорость следующей мишени NOTE: ?!

            // Создание и добавление новой мишени в список
            _targets.Add(new Target(this, color, HitReward, targetX, targetY,
               (int) (TargetWidthPercent * ScreenWidth),
               (int) (TargetLengthPercent * ScreenHeight),
               (int) velocity));

            // Увеличение координаты x для смещения следующей мишени вправо
            targetX += (int) ((TargetWidthPercent + TargetSpacingPercent) * ScreenWidth);
         }

         // Создание нового блока
         _blocker = new Blocker(this,
            Color.Black,
            MissPenalty,
            (int) (BlockerXPercent * ScreenWidth),
            (int) ((0.5 - BlockerLengthPercent / 2) * ScreenHeight),
            (int) (BlockerWidthPercent * ScreenWidth),
            (int) (BlockerLengthPercent * ScreenHeight),
            (float) (BlockerSpeedPercent * ScreenHeight));

         _timeLeft = 10; // Обратный отсчет с 10-ти секунд
         _shotsFired = 0; // Начальное кол-во выстрелов
         _totalElapsedTime = 0.0; // Обнулить затраченное время

         if (_gameOver) // Начать новую игру после завершения предыдущей
         {
            _gameOver = false; // Игра не закончена
            _cannonThread = new CannonThread(Holder, this); // Создать поток
            _cannonThread.Start(); // Запуск потока игрового цикла
         }

         HideSystemBars();
      }

      /// <summary>
      ///    Сокрытие системных панелей и панели приложения
      /// </summary>
      private void HideSystemBars()
      {
         if (_MoreOrEqualThanKitKatFunc())
            SystemUiVisibility = (StatusBarVisibility) (LayoutStable | HideNavigation | Fullscreen |
                                                        LayoutHideNavigation | LayoutFullscreen | Immersive);
      }

      /// <summary>
      ///    Многократно вызывается <see cref="CannonThread" /> для обновления элементов игры
      /// </summary>
      /// <param name="elapsedTimeMs">Частота обновления в мс</param>
      private void UpdatePositions(double elapsedTimeMs)
      {
         var interval = elapsedTimeMs / 1000.0; // Преобразовать в секунды         
         _cannon.CannonBall?.Update(interval); // Обновление позиции ядра
         _blocker.Update(interval); // Обновление позиции блока
         _targets.ForEach(target => target.Update(interval)); // Обновление позиции мишени
         _timeLeft -= interval; // Уменьшение оставшегося времени

         // Если счетчик достиг нуля
         if (_timeLeft <= 0)
         {
            _timeLeft = 0.0;
            _gameOver = true; // Игра закончена
            _cannonThread.SetRunning(false); // Завершение потока
            ShowGameOverDialog(StringRes.lose); // Сообщение о проигрыше
         }

         // Если все мишени поражены
         if (_targets.Count == 0)
         {
            _cannonThread.SetRunning(false); // Завершение потока
            ShowGameOverDialog(StringRes.win); // Сообщение о выигрыше
            _gameOver = true;
         }
      }

      /// <summary>
      ///    Метод определяет угол наклона ствола и стреляет из пушки,
      ///    если ядро не находится на экране
      /// </summary>
      /// <param name="motionEvent">Событие касания</param>
      private void AlignAndFireCannonBall(MotionEvent motionEvent)
      {
         // Получение точки касания в этом представлении
         var touchPoint = new Point((int) motionEvent.GetX(), (int) motionEvent.GetY());

         // Вычисление расстояния точки касания от центра экрана по оси y
         var centerMinusY = ScreenHeight / 2 - touchPoint.Y;
         var angle = Math.Atan2(touchPoint.X, centerMinusY); // Вычислить угол ствола относительно горизонтали
         _cannon.Align(angle); // Ствол наводится в точку касания

         // Пушка стреляет, если ядро не находится на экране
         if (_cannon.CannonBall == null || !_cannon.CannonBall.OnScreen)
         {
            _cannon.FireCannonBall();
            ++_shotsFired;
         }
      }

      /// <summary>
      ///    Отображение окна AlertDialog при завершении игры
      /// </summary>
      /// <param name="stringResource">Строковый ресурс</param>
      private void ShowGameOverDialog(int stringResource) // TODO: Лучше сразу передавать строку
      {
         DialogFragment gameResult = new GameOverDialogFragment(stringResource, this);

         // В UI-потоке FragmentManager используется для вывода DialogFragment
         _activity.RunOnUiThread(() =>
         {
            ShowSystemBars(); // Выход из режима погружения
            _dialogIsDisplayed = true;
            gameResult.Cancelable = false; // Модальное окно
            gameResult.Show(_activity.SupportFragmentManager, ResultsTag);
         });
      }

      /// <summary>
      ///    Рисование элементов игры
      /// </summary>
      /// <param name="canvas">Холст</param>
      private void DrawGameElements(Canvas canvas)
      {
         canvas.DrawRect(0, 0, canvas.Width, canvas.Height, _backgroundPaint); // Очистка фона         
         canvas.DrawText(Resources.GetString(StringRes.time_remaining_format, _timeLeft), 50, 100,
            _textPaint); // Вывод оставшегося времени
         _cannon.Draw(canvas); // Рисование пушки

         // Рисование игровых элементов
         if (_cannon?.CannonBall?.OnScreen == true) _cannon.CannonBall.Draw(canvas);

         _blocker.Draw(canvas); // Рисование блока         
         _targets.ForEach(target => target.Draw(canvas)); // Рисование всех мишеней
      }

      /// <summary>
      ///    Проверка столкновений с блоками или мишенями и обработка столкновений
      /// </summary>
      private void TestForCollisions()
      {
         if (_cannon?.CannonBall == null)
            return;

         var cannonBall = _cannon.CannonBall;

         // Удаление мишеней, с которыми сталкивается ядро
         if (cannonBall.OnScreen)
            for (var n = 0; n < _targets.Count; n++)
               if (cannonBall.CollidesWith(_targets[n]))
               {
                  _targets[n].PlaySound(); // Звук попадания в мишень
                  _timeLeft += _targets[n].HitReward; // Прибавление награды к оставшемуся времени
                  _cannon.RemoveCannonBall(); // Удаление ядра из игры
                  _targets.RemoveAt(n); // Удаление пораженной мишени NOTE: Плохая коллекция для удаления элементов
                  --n; // Чтобы не пропустить проверку новой мишени
                  break; // NOTE: WAF?!
               }
               else
               {
                  _cannon?.RemoveCannonBall();
               }

         // Проверка столкновения с блоком
         if (cannonBall.CollidesWith(_blocker))
         {
            _blocker.PlaySound();
            cannonBall.ReverseVelocityX(); // Изменение направления
            _timeLeft -= _blocker.MissPenalty; // Уменьшение оставшегося времени на величину штрафа
         }
      }

      /// <summary>
      ///    Вывести системные панели и панель приложения
      /// </summary>
      private void ShowSystemBars()
      {
         if (_MoreOrEqualThanKitKatFunc())
            SystemUiVisibility = (StatusBarVisibility) (LayoutStable | LayoutHideNavigation | LayoutFullscreen);
      }

      /// <summary>
      ///    DialogFragment для вывода статистики и начала новой игры
      /// </summary>
      private sealed class GameOverDialogFragment : DialogFragment
      {
         private readonly CannonView _cannonView;
         private readonly int _messageId;

         public GameOverDialogFragment(int messageId, CannonView cannonView)
         {
            _messageId = messageId;
            _cannonView = cannonView;
         }

         public override Dialog OnCreateDialog(Bundle savedInstanceState) =>
            new AlertDialog.Builder(_cannonView._activity)
               .SetTitle(_cannonView._activity.Resources.GetString(_messageId))
               // Вывод кол-ва выстрелов и затраченного времени
               .SetMessage(
                  _cannonView._activity.Resources.GetString(
                     StringRes.results_format, _cannonView._shotsFired, _cannonView._totalElapsedTime))
               .SetPositiveButton(StringRes.reset_game,
                  (sender, args) =>
                  {
                     _cannonView._dialogIsDisplayed = false;
                     _cannonView.NewGame(); // Создание и начало новой партии
                  })
               .Create();
      }

      private sealed class SurfaceHolderCallbackImpl : JavaObj, ISurfaceHolderCallback
      {
         private readonly CannonView _cannonView;

         public SurfaceHolderCallbackImpl(CannonView cannonView) => _cannonView = cannonView;

         public void SurfaceChanged(ISurfaceHolder holder, Format format, int width, int height)
         {
         }

         public void SurfaceCreated(ISurfaceHolder holder)
         {
            if (!_cannonView._dialogIsDisplayed)
            {
               _cannonView.NewGame(); // Создание новой игры
               _cannonView._cannonThread = new CannonThread(holder, _cannonView); // Создание потока
               _cannonView._cannonThread.SetRunning(true); // Запуск игры
               _cannonView._cannonThread.Start(); // Запуск потока игрового цикла
            }
         }

         public void SurfaceDestroyed(ISurfaceHolder holder)
         {
            var retry = true; // Обеспечить корректную зависимость потока
            _cannonView._cannonThread.SetRunning(false); // Завершение cannonThread

            while (retry)
               try
               {
                  _cannonView._cannonThread.Join(); // Ожидать завершения cannonThread
                  retry = false;
               }
               catch (InterruptedException interruptedEx)
               {
                  Log.Error(ErrorTag, "Thread interrupted", interruptedEx);
               }
         }
      }

      /// <summary>
      ///    Управление циклом игры
      /// </summary>
      private sealed class CannonThread : Thread
      {
         private readonly CannonView _cannonView;
         private readonly ISurfaceHolder _surfaceHolder; // Для работы с Canvas
         private bool _threadIsRunning = true;

         internal CannonThread(ISurfaceHolder surfaceHolder, CannonView cannonView)
         {
            _surfaceHolder = surfaceHolder;
            _cannonView = cannonView;
            Name = nameof(CannonThread);
         }

         /// <summary>
         ///    Изменение состояния выполнения
         /// </summary>
         /// <param name="isRunning"></param>
         internal void SetRunning(bool isRunning) => _threadIsRunning = isRunning;

         public override void Run()
         {
            Canvas canvas = null; // Используется для рисования
            var previousFrameTime = JavaSystem.CurrentTimeMillis();

            while (_threadIsRunning)
               try
               {
                  // Получение Canvas для монопольного рисования из этого потока
                  canvas = _surfaceHolder.LockCanvas();

                  // Блокировка surfaceHolder для рисования
                  lock (_surfaceHolder)
                  {
                     var currentTime = JavaSystem.CurrentTimeMillis();
                     var elapsedTimeMs = currentTime - previousFrameTime;
                     _cannonView._totalElapsedTime += elapsedTimeMs / 1000.0;
                     _cannonView.UpdatePositions(elapsedTimeMs); // Обновление состояния игры
                     _cannonView.TestForCollisions(); // Проверка столкновений
                     _cannonView.DrawGameElements(canvas); // Рисование на объекте canvas
                     previousFrameTime = currentTime; // Обновление времени
                  }
               }
               finally
               {
                  // Вывести содержимое canvas на CannonView и разрешить использовать Canvas другим потокам
                  if (canvas != null) _surfaceHolder.UnlockCanvasAndPost(canvas);
               }
         }
      }
   }
}