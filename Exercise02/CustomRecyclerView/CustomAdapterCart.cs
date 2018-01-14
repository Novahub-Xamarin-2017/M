using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android;
using System.Collections.Generic;
using Exercise02.CustomRecyclerView.Models;
using Android.Util;
using Android.Graphics;
using Android.Runtime;

namespace Exercise02.CustomRecyclerView
{
    class CustomAdapterCart : RecyclerView.Adapter
    {
        List<Item> items;

        public CustomAdapterCart()
        {
        }

        public CustomAdapterCart(List<Item> data)
        {
            items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here

            var id = Resource.Layout.CardViewBill;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new CustomAdapterCartViewHolder(itemView);
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as CustomAdapterCartViewHolder;

            var imageAsBytes = Base64.Decode(item.Image, Base64Flags.Default);
            var imageAsBitmap = BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);

            holder.ImageViewIcon.SetImageBitmap(imageAsBitmap);
            holder.TextViewName.Text = item.Name;
            holder.TextViewPricePerUnit.Text = $"Rs. {item.PricePerUnit}";
            holder.TextViewAmount.Text = $"x {item.Value}";

            var sum = int.Parse(item.PricePerUnit) * int.Parse(item.Value);

            holder.TextViewValue.Text = $"= {sum}";
        }

        public override int ItemCount => items.Count;
    }

    public class CustomAdapterCartViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ImageViewIcon { get; set; }
        public TextView TextViewName { get; set; }
        public TextView TextViewPricePerUnit { get; set; }
        public TextView TextViewAmount { get; set; }
        public TextView TextViewValue { get; set; }

        public CustomAdapterCartViewHolder(View itemView) : base(itemView)
        {
            ImageViewIcon = itemView.FindViewById<ImageView>(Resource.Id.image);
            TextViewName = itemView.FindViewById<TextView>(Resource.Id.name);
            TextViewAmount = itemView.FindViewById<TextView>(Resource.Id.tv_amount);
            TextViewPricePerUnit = itemView.FindViewById<TextView>(Resource.Id.tv_priceperunit);
            TextViewValue = itemView.FindViewById<TextView>(Resource.Id.tv_value);
        }
    }
}