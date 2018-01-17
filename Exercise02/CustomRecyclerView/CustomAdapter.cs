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
    class CustomAdapter : RecyclerView.Adapter
    {
        private List<Order> orders;

        public CustomAdapter(List<Order> orders)
        {
            this.orders = orders;
        }

        protected CustomAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.CardView;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new CustomAdapterViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((CustomAdapterViewHolder)viewHolder).SetViewHolder(orders[position]);
        }

        public override int ItemCount => orders.Count;
    }

    public class CustomAdapterViewHolder : RecyclerView.ViewHolder
    {
        private ImageView imageViewIcon;

        private TextView textViewName;

        private TextView textViewPricePerUnit;

        private TextView textViewUnit;

        private TextView textViewQuantity;

        public CustomAdapterViewHolder(View itemView) : base(itemView)
        {
            imageViewIcon = itemView.FindViewById<ImageView>(Resource.Id.image);
            textViewName = itemView.FindViewById<TextView>(Resource.Id.name);
            textViewUnit = itemView.FindViewById<TextView>(Resource.Id.tv_unit);
            textViewPricePerUnit = itemView.FindViewById<TextView>(Resource.Id.tv_priceperunit);
            textViewQuantity = itemView.FindViewById<TextView>(Resource.Id.tv_value);

            itemView.FindViewById<ImageButton>(Resource.Id.minus).Click += delegate
            {
                var quantity = int.Parse(textViewQuantity.Text);

                if (quantity > 0)
                {
                    quantity--;
                    textViewQuantity.Text = quantity.ToString();
                }
            };

            itemView.FindViewById<ImageButton>(Resource.Id.plus).Click += delegate
            {
                var quantity = int.Parse(textViewQuantity.Text);
                quantity++;
                textViewQuantity.Text = quantity.ToString();
            };
            
            textViewQuantity.TextChanged += delegate
            {
                OrderController.ListOfItem[AdapterPosition].Quantity = int.Parse(textViewQuantity.Text);
            };
        }

        public void SetViewHolder(Order order)
        {
            var imageAsBytes = Base64.Decode(order.Image, Base64Flags.Default);
            var imageAsBitmap = BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);

            imageViewIcon.SetImageBitmap(imageAsBitmap);
            textViewName.Text = order.Name;
            textViewPricePerUnit.Text = $"Rs. {order.PricePerUnit}";
            textViewUnit.Text = order.Unit;
            textViewQuantity.Text = order.Quantity.ToString();
        }
    }
}