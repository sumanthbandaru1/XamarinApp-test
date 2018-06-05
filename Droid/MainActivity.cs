﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using CarouselView.FormsPlugin.Android;
using Xamarin.Forms;
using KickassUI.Runkeeper.Helpers;
using FormsToolkit;
using Android.Text.Style;
using Android.Text;

namespace KickassUI.Runkeeper.Droid
{
    [Activity(Label = "KickassUI Runkeeper", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.ToolbarWithLogo;

            CachedImageRenderer.Init();
            CarouselViewRenderer.Init();
            Xamarin.FormsMaps.Init(this, bundle);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());

            // Remove the logo when we're not on the main page.
            MessagingService.Current.Subscribe<bool>(MessageKeys.ChangeToolbar, (page, showImage) =>
            {
                // Change the toolbar to be without logo
                if (showImage)
                    ToolbarResource = Resource.Layout.ToolbarWithLogo;
                else
                    ToolbarResource = Resource.Layout.Toolbar;
            });
        }
    }
}
