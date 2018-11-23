﻿using System.IO;
using Android.Graphics;
using Android.OS;
using Path = System.IO.Path;
using JFile=Java.IO.File;

namespace PointOfViewApp.Poco
{
   public static class PointOfInterestExtensions
   {
      private const string AppName = "POIApp";
      private const string ImageNamePrefix = "poiimage";

      public static string GetFileName(this PointOfInterest interest) => interest.Id.GetFileName();

      public static string GetFileName(this int poiId)
      {
         var storagePath = Path.Combine(Environment.ExternalStorageDirectory.Path, AppName);
         var path = Path.Combine(storagePath, $"{ImageNamePrefix}{poiId}.jpg");
         return path;
      }

      public static Bitmap GetImage(this PointOfInterest interest) => interest.Id.GetImage();

      public static Bitmap GetImage(this int poiId)
      {
         var fileName = poiId.GetFileName();
         if (File.Exists(fileName))
         {
            var imageFile = new JFile(fileName);
            return BitmapFactory.DecodeFile(imageFile.Path);
         }

         return null;
      }

      public static void DeleteImage(this PointOfInterest interest) => interest.Id.DeleteImage();

      public static void DeleteImage(this int poiId)
      {
         var filePath = poiId.GetFileName();
         if (File.Exists(filePath))
         {
            File.Delete(filePath);
         }
      }
   }
}