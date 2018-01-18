using Android.App;
using Android.Widget;
using Android.OS;
using Exercise02.CustomRecyclerView;
using Android.Support.V7.Widget;
using System.IO;
using Newtonsoft.Json;
using Exercise02.CustomRecyclerView.Models;
using System.Collections.Generic;
using Android.Content;
using System.Linq;

namespace Exercise02
{
    [Activity(Label = "Exercise02", Theme = "@android:style/Theme.Material.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private AdapterOrder adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            var input = Assets.Open("Data.json");

            using (var streamReader = new StreamReader(input))
            {
                var content = streamReader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<Order>>(content);
                adapter = new AdapterOrder(items, true);
                recyclerView.SetAdapter(adapter);
            }

            FindViewById<ImageButton>(Resource.Id.imagebtn_cart).Click += delegate
            {
                var intent = new Intent(this, typeof(Cart));
                intent.PutExtra("quantitys", adapter.Orders.Select(x=>x.Quantity.ToString()).ToArray());

                StartActivity(intent);
            };
        }
    }
}

