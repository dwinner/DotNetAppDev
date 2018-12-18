﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.Util;
using Android.Views;
using AppDevUnited.CannonGame.App.GameElements;
using Java.Lang;
using JavaObj = Java.Lang.Object;
using RawRes = AppDevUnited.CannonGame.App.Resource.Raw;
using ColorRes = AppDevUnited.CannonGame.App.Resource.Color;

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
      private const double CannonballRadiusPercent = 0.0375D;
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
      private Activity _activity; // Для отображения окна в потоке GUI
      private Paint _backgroundPaint; // Для стирания области рисования
      private Blocker _blocker;

      // Игровые объекты
      private Cannon _cannon;

      private CannonThread _cannonThread; // Управляет циклом игры
      private bool _dialogIsDisplayed = false;

      // Переменные размеров

      // Переменные для игрового цикла и отслеживания состояния игры
      private bool _gameOver; // Игра закончена
      private int _shotsFired; // Кол-во сделанных выстрелов
      private readonly SparseIntArray _soundMap; // Связь идентификаторов с SoundPool

      private readonly SoundPool _soundPool; // Воспроизведение звуков
      private ISurfaceHolderCallback _surfaceHolderCallback;
      private List<Target> _targets;

      // Переменные Paint для рисования элементов на экране
      private readonly Paint _textPaint; // Для вывода текста
      private double _timeLeft; // Оставшееся время в секундах
      private double _totalElapsedTime; // Затраты времени в секундах

      public CannonView(Context context, IAttributeSet attrs)
         : base(context, attrs)
      {
         _activity = (Activity) context; // Ссылка на MainActivity
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
      public int ScreenWidth { get; private set; }

      /// <summary>
      ///    Получение высоты экрана
      /// </summary>
      public int ScreenHeight { get; private set; }

      protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
      {
         base.OnSizeChanged(w, h, oldw, oldh);

         ScreenWidth = w; // Сохранение ширины CannonView
         ScreenHeight = h; // Сохранение высоты CannonView

         // Настройка свойств текста
         _textPaint.TextSize = (int) (TextSizePercent * ScreenHeight);
         _textPaint.AntiAlias = true; // Сглаживание текста
      }

      public void StopGame()
      {
         throw new NotImplementedException();
      }

      public void ReleaseResources()
      {
         throw new NotImplementedException();
      }

      public void PlaySound(int soundId) => _soundPool.Play(_soundMap.Get(soundId), 1, 1, 1, 0, 1F);

      /// <summary>
      ///    Сброс всех экранных элементов
      /// </summary>
      public void NewGame()
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
            _cannonThread = new CannonThread(Holder); // Создать поток
            _cannonThread.Start(); // Запуск потока игрового цикла
         }

         HideSystemBars();
      }

      private void HideSystemBars()
      {
         throw new NotImplementedException();
      }

      private sealed class SurfaceHolderCallbackImpl : JavaObj, ISurfaceHolderCallback
      {
         private readonly CannonView _cannonView;

         public SurfaceHolderCallbackImpl(CannonView cannonView) => _cannonView = cannonView;

         public void SurfaceChanged(ISurfaceHolder holder, Format format, int width, int height)
         {
            throw new NotImplementedException();
         }

         public void SurfaceCreated(ISurfaceHolder holder)
         {
            throw new NotImplementedException();
         }

         public void SurfaceDestroyed(ISurfaceHolder holder)
         {
            throw new NotImplementedException();
         }
      }

      private sealed class CannonThread : Thread
      {
         public CannonThread(ISurfaceHolder holder) => throw new NotImplementedException();
      }
   }
}