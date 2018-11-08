﻿using System;
using System.IO;
using System.Text;
using Android.Content;
using Resources.Interfaces;
using Resources.Misc;
using StringResources = Resources.Resource.String;
using ArrayResources = Resources.Resource.Array;
using PluralResources = Resources.Resource.Plurals;
using ColorResources = Resources.Resource.Color;
using DimensionResources = Resources.Resource.Dimension;
using RawResources = Resources.Resource.Raw;
using String = Java.Lang.String;
using XmlResources = Resources.Resource.Xml;

namespace Resources
{
   public class ResourceTester : BaseTester
   {
      private const string Tag = nameof(ResourceTester);

      public ResourceTester(IReportBack reportTo, Context context)
         : base(reportTo, context)
      {
      }

      public void TestEnStrings()
      {
         var msg = "available in all en/us/root/port/en_port: test_en_us";
         ReportString(msg, StringResources.teststring_all);

         msg = "available in only root/en and port: t1_enport";
         ReportString(msg, StringResources.t1_enport);

         msg = "available in only root/en/port: t1_en_port";
         ReportString(msg, StringResources.t1_1_en_port);

         msg = "available in only root: t2";
         ReportString(msg, StringResources.t2);

         msg = "available in only port/root: testport_port";
         ReportString(msg, StringResources.testport_port);
      }

      public void TestStringArray() => ReportArray(ArrayResources.test_array);

      public void TestPlurals()
      {
         ReportPlurals(PluralResources.test_plurals, 0);
         ReportPlurals(PluralResources.test_plurals, 1);
         ReportPlurals(PluralResources.test_plurals, 2);
         ReportPlurals(PluralResources.test_plurals, 3);
      }

      public void TestColors()
      {
         var resources = Context.Resources;
         var color = resources.GetColor(ColorResources.main_back_ground_color, null);
         ReportString($"mainBackGroundColor:{color}");
      }

      public void TestDimensions()
      {
         var resources = Context.Resources;
         ReportString($"Dimen:{resources.GetDimension(DimensionResources.medium_size)}");
         ReportString($"Dimen:{resources.GetDimension(DimensionResources.mysize_in_dp)}");
         ReportString($"Dimen:{resources.GetDimension(DimensionResources.mysize_in_pixels)}");
      }

      public void TestStringVariations()
      {
         // Read a simple string and set it in a text view
         var simpleString = Context.GetString(StringResources.simple_string);
         ReportString(simpleString);

         // Read a quoted string and set it in a text view
         var quotedString = Context.GetString(StringResources.quoted_string);
         ReportString(quotedString);

         // Read a double quoted string and set it in a text view
         var doubleQuotedString = Context.GetString(StringResources.double_quoted_string);
         ReportString(doubleQuotedString);

         // Read a Java format string
         var javaFormatString = Context.GetString(StringResources.java_format_string);

         // Convert the formatted string by passing in arguments
         var substitutedString = String.Format(javaFormatString, "Hello", "Android");

         // set the output in a text view
         ReportString(substitutedString);

         // Read an html string from the resource and set it in a text view
         // string htmlTaggedString = Context.GetString(StringResources.tagged_string);
         // Convert it to a text span so that it can be set in a text view
         // android.text.Html class allows painting of "html" strings
         // This is strictly an Android class and does not support all html tags
         // var textSpan = Android.Text.Html.FromHtml(htmlTaggedString,FromHtmlOptions.ModeCompact);         
         // Set it in a text view
         // this.GetTextView().setText(textSpan);
      }

      public void TestAssets() => ReportString(GetStringFromAssetFile(Context));

      public void TestRawFile() => ReportString(GetStringFromRawFile(Context));

      public void TestXml() => ReportString(GetEventsFromXmlFile(Context));

      private void ReportString(string str) => ReportTo.ReportBack(Tag, str);

      private void ReportPlurals(int pluralResource, int amount)
      {
         var resources = Context.Resources;
         var quantityString = resources.GetQuantityString(pluralResource, amount);
         ReportTo.ReportBack(Tag, quantityString);
      }

      private void ReportArray(int arrayResource)
      {
         var resources = Context.Resources;
         var strings = resources.GetStringArray(arrayResource);
         Array.ForEach(strings, item => ReportTo.ReportBack(Tag, item));
      }

      private void ReportString(string msg, int stringResource)
      {
         ReportTo.ReportBack(Tag, msg);
         Report(stringResource);
      }

      private void Report(int stringId) => ReportTo.ReportBack(Tag, Context.GetString(stringId));

      private string GetStringFromAssetFile(Context activity)
      {
         var assetManager = activity.Assets;
         using (var streamReader = new StreamReader(assetManager.Open("test.txt")))
         {
            return streamReader.ReadToEnd();
         }
      }

      private string GetStringFromRawFile(Context activity)
      {
         var resources = activity.Resources;
         using (var reader = new StreamReader(resources.OpenRawResource(RawResources.test)))
         {
            return reader.ReadToEnd();
         }
      }

      private string GetEventsFromXmlFile(Context activity)
      {
         var stringBuilder = new StringBuilder();
         var resources = activity.Resources;
         var reader = resources.GetXml(XmlResources.test);
         // TODO: Read XML in .NET way

         return string.Empty;
      }
   }
}