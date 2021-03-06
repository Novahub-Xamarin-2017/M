﻿using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;

namespace Exercise03
{
    [Activity(Label = "Image", Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class Image : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Image);

            var imageView = FindViewById<ImageView>(Resource.Id.imv_image);

            var fileImage = Intent.GetStringExtra("path");
            imageView.SetImageURI(Uri.FromFile(new File(fileImage)));
        }
    }
}