﻿using Android.OS;
using Android.Views;
using FragmentV4 = Android.Support.V4.App.Fragment;

namespace FlagQuiz.App
{
   public class SettingsActivityFragment : FragmentV4
   {
      public override void OnCreate(Bundle savedInstanceState)
      {
         base.OnCreate(savedInstanceState);

         // Create your fragment here
      }

      public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
      {
         // Use this to return your custom view for this Fragment
         // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

         return base.OnCreateView(inflater, container, savedInstanceState);
      }
   }
}