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
using Exercise02.CustomRecyclerView;
using Android.Support.V7.Widget;
using Exercise02.CustomRecyclerView.Models;
using Newtonsoft.Json;
using System.IO;

namespace Exercise02
{
    [Activity(Label = "Cart", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class Cart : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Cart);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            var quantitys = Intent.GetStringArrayExtra("quantitys");


             //var adapter = new CustomAdapterCart(itemsSelected);

             //recyclerView.SetAdapter(adapter);

             var input = Assets.Open("Data.json");

            using (var streamReader = new StreamReader(input))
            {
                var content = streamReader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<Order>>(content);

                var index = 0;

                foreach(var item in items)
                {
                    item.Quantity = int.Parse(quantitys[index]);
                    index++;
                }

                var itemsSelected = items.Where(x => x.Quantity != 0).ToList();

                FindViewById<TextView>(Resource.Id.tv_sum).Text = $"Price = {itemsSelected.Sum(x => x.PricePerUnit * x.Quantity)}";

                var adapter = new AdapterOrder(itemsSelected, "Cart");
                recyclerView.SetAdapter(adapter);
            }
        }
    }
}