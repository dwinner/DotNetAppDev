﻿using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace Resources
{
   [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
   public class MainActivity : AppCompatActivity
   {
      protected override void OnCreate(Bundle savedInstanceState)
      {
         base.OnCreate(savedInstanceState);
         SetContentView(Resource.Layout.activity_main);

         var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
         SetSupportActionBar(toolbar);

         var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
         fab.Click += FabOnClick;
      }

      public override bool OnCreateOptionsMenu(IMenu menu)
      {
         MenuInflater.Inflate(Resource.Menu.main_menu, menu);
         return true;
      }

      public override bool OnOptionsItemSelected(IMenuItem item)
      {
         //var id = item.ItemId;
         //if (id == Resource.Id.action_settings)
         //   return true;
         // NOTE: Implement me
         return base.OnOptionsItemSelected(item);
      }

      private void FabOnClick(object sender, EventArgs eventArgs)
      {
         var view = (View) sender;
         Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
            .SetAction("Action", (View.IOnClickListener) null).Show();
      }
   }
}