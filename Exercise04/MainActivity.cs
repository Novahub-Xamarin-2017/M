using Android.App;
using Android.Widget;
using Android.OS;
using Exercise044.Adapters;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise044.Models;
using Exercise044.Fragments;

namespace Exercise044
{
    [Activity(Label = "Exercise04", Theme = "@android:style/Theme.Material.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.btn_app).Click += delegate
            {
                var fragmentManager = FragmentManager.BeginTransaction();
                fragmentManager.Replace(Resource.Id.frameLayout1, new FragmentApp());
                fragmentManager.Commit();
            };

            FindViewById<Button>(Resource.Id.btn_book).Click += delegate
            {
                var fragmentManager = FragmentManager.BeginTransaction();
                fragmentManager.Replace(Resource.Id.frameLayout1, new FragmentBook());
                fragmentManager.Commit();
            };

            FindViewById<Button>(Resource.Id.btn_game).Click += delegate
            {
                var fragmentManager = FragmentManager.BeginTransaction();
                fragmentManager.Replace(Resource.Id.frameLayout1, new FragmentGame());
                fragmentManager.Commit();
            };
        }
    }
}

