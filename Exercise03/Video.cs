using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;

namespace Exercise03
{
    [Activity(Label = "Video", Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class Video : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Video);

            var videoView = FindViewById<VideoView>(Resource.Id.vdv_video);

            var fileImage = Intent.GetStringExtra("path");
            videoView.SetVideoURI(Android.Net.Uri.FromFile(new File(fileImage)));
            videoView.Start();
        }
    }
}