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

            var itemsSelected = OrderController.ListOfItem.Where(x => x.Quantity != 0).ToList();

            FindViewById<TextView>(Resource.Id.tv_sum).Text = $"Price = {itemsSelected.Sum(x => x.PricePerUnit * x.Quantity)}";

            var adapter = new CustomAdapterCart(itemsSelected);

            recyclerView.SetAdapter(adapter);
        }
    }
}