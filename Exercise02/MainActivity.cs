using Android.App;
using Android.Widget;
using Android.OS;
using Exercise02.CustomRecyclerView;
using Android.Support.V7.Widget;
using System.IO;
using Newtonsoft.Json;
using Exercise02.CustomRecyclerView.Models;
using System.Collections.Generic;

namespace Exercise02
{
    [Activity(Label = "Exercise02", Theme = "@android:style/Theme.Material.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            var adapter = new CustomAdapter();
            var input = Assets.Open("Data.json");

            using (var streamReader = new StreamReader(input))
            {
                var content = streamReader.ReadToEnd();
                Items.ListOfItem = JsonConvert.DeserializeObject<List<Item>>(content);

                adapter = new CustomAdapter(Items.ListOfItem);
            }

            recyclerView.SetAdapter(adapter);

            FindViewById<ImageButton>(Resource.Id.imagebtn_cart).Click += delegate
            {
                StartActivity(typeof(Cart));
            };
        }
    }
}

