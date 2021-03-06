﻿using Android.App;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;
using System.IO;
using Exercise01.CustomRecyclerView.Models;
using System.Collections.Generic;
using Exercise01.CustomRecyclerView;
using Android.Support.V7.Widget;

namespace Exercise01
{
    [Activity(Label = "Exercise01", Theme = "@android:style/Theme.Material.Light.DarkActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private CustomAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.my_recycler_view);

            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            var input = Assets.Open("Data.json");

            using (var streamReader = new StreamReader(input))
            {
                var content = streamReader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<AndroidVersion>>(content);
                adapter = new CustomAdapter(items);
                recyclerView.SetAdapter(adapter);
            }
        }
    }
}

