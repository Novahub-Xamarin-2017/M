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
        private List<Order> orders;

        public CustomAdapterCart(List<Order> orders)
        {
            this.orders = orders;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.CardViewBill;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new CustomAdapterCartViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((CustomAdapterCartViewHolder)viewHolder).SetCartViewHoler(orders[position]);
        }

        public override int ItemCount => orders.Count;
    }

    public class CustomAdapterCartViewHolder : RecyclerView.ViewHolder
    {
        private ImageView imageViewIcon;

        private TextView textViewName;

        private TextView textViewPricePerUnit;

        private TextView textViewAmount;

        private TextView textViewPrice;

        public CustomAdapterCartViewHolder(View itemView) : base(itemView)
        {
            imageViewIcon = itemView.FindViewById<ImageView>(Resource.Id.image);
            textViewName = itemView.FindViewById<TextView>(Resource.Id.name);
            textViewAmount = itemView.FindViewById<TextView>(Resource.Id.tv_amount);
            textViewPricePerUnit = itemView.FindViewById<TextView>(Resource.Id.tv_priceperunit);
            textViewPrice = itemView.FindViewById<TextView>(Resource.Id.tv_value);
        }

        public void SetCartViewHoler(Order order)
        {
            var imageAsBytes = Base64.Decode(order.Image, Base64Flags.Default);
            var imageAsBitmap = BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);

            imageViewIcon.SetImageBitmap(imageAsBitmap);
            textViewName.Text = order.Name;
            textViewPricePerUnit.Text = $"Rs. {order.PricePerUnit}";
            textViewAmount.Text = $"x {order.Quantity}";

            var sum = order.PricePerUnit * order.Quantity;

            textViewPrice.Text = $"= {sum}";
        }
    }
}