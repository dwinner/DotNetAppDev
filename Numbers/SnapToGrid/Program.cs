﻿/**
 * Округление точек на сетке
 */

using System;
using System.Windows.Forms;

namespace SnapToGrid
{
   internal static class Program
   {
      [STAThread]
      private static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }
   }
}