﻿using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Windows;
using FirstsStepsRUI.Models;
using FirstsStepsRUI.Repositories.Abstracts;
using ReactiveUI;

namespace FirstsStepsRUI.ViewModels
{
   public class MenuViewModel : ReactiveObject
   {
      private MenuOptionViewModel _selectedOption;

      private User _user;

      public MenuViewModel(IUserRepository userRepository)
      {
         if (userRepository == null)
            throw new ArgumentNullException("userRepository");

         Menu = new ReactiveList<MenuOptionViewModel>();

         // Use WhenAny to observe one or more values
         var canLoadMenu = this.WhenAny(m => m.User, user => user.Value != null);

         // hook function to command, shouldn't contain UI/complex logic
         LoadMenu = ReactiveCommand.CreateAsyncTask(canLoadMenu, _ => userRepository.GetMenuByUserAsync(User));

         // RxApp.MainThreadScheduler is our UI thread, you can go wild here
         LoadMenu.ObserveOn(RxApp.MainThreadScheduler).Subscribe(menu =>
         {
            Menu.Clear();
            foreach (var option in menu)
            {
               var menuOption = new MenuOptionViewModel(option);
               Menu.Add(menuOption);
            }
         });

         LoadMenu.ThrownExceptions.Subscribe(ex =>
         {
            Menu.Clear();
            MessageBox.Show(ex.Message);
         });

         // Use WhenAnyValue to check if a property was changed
         // If user was changed reload menu
         this.WhenAnyValue(m => m.User).InvokeCommand(this, vm => vm.LoadMenu);
      }

      private ReactiveCommand<IList<Menu>> LoadMenu { get; set; }
      public ReactiveList<MenuOptionViewModel> Menu { get; private set; }

      public User User
      {
         get { return _user; }
         set { this.RaiseAndSetIfChanged(ref _user, value); }
      }

      public MenuOptionViewModel SelectedOption
      {
         get { return _selectedOption; }
         set { this.RaiseAndSetIfChanged(ref _selectedOption, value); }
      }
   }
}