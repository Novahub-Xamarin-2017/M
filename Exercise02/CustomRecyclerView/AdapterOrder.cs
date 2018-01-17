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
    class AdapterOrder : RecyclerView.Adapter
    {
        private List<Order> orders;

        private string viewMode;

        public List<Order> Orders
        {
            get => orders;
        }

        public AdapterOrder(List<Order> orders, string viewMode)
        {
            this.orders = orders;
            this.viewMode = viewMode;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewMode.Equals("Order"))
            {
                var id = Resource.Layout.CardView;
                var itemView = LayoutInflater.From(parent.Context).
                       Inflate(id, parent, false);

                return new AdapterViewHolderOrder(itemView);
            }
            else
            {
                var id = Resource.Layout.CardViewBill;
                var itemView = LayoutInflater.From(parent.Context).
                       Inflate(id, parent, false);

                return new AdapterViewHolderCart(itemView);
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            if (viewMode.Equals("Order"))
            {
                ((AdapterViewHolderOrder)viewHolder).Order = orders[position];
            }
            else
            {
                ((AdapterViewHolderCart)viewHolder).Order = orders[position];
            }
        }

        public override int ItemCount => orders.Count;
    }

    public class AdapterViewHolderOrder : RecyclerView.ViewHolder
    {
        private ImageView imageViewIcon;

        private TextView textViewName;

        private TextView textViewPricePerUnit;

        private TextView textViewUnit;

        private TextView textViewQuantity;

        private Order order;

        public Order Order
        {
            get => order;
            set
            {
                order = value;
                SetView();
            }
        }

        public AdapterViewHolderOrder(View itemView) : base(itemView)
        {
            imageViewIcon = itemView.FindViewById<ImageView>(Resource.Id.image);
            textViewName = itemView.FindViewById<TextView>(Resource.Id.name);
            textViewUnit = itemView.FindViewById<TextView>(Resource.Id.tv_unit);
            textViewPricePerUnit = itemView.FindViewById<TextView>(Resource.Id.tv_priceperunit);
            textViewQuantity = itemView.FindViewById<TextView>(Resource.Id.tv_value);

            itemView.FindViewById<ImageButton>(Resource.Id.minus).Click += delegate
            {
                MinusQuantity(1);
            };

            itemView.FindViewById<ImageButton>(Resource.Id.plus).Click += delegate
            {
                PlusQuantity(1);
            };
        }

        private void MinusQuantity(int amount)
        {
            if (order.Quantity > 0)
            {
                order.Quantity--;
                textViewQuantity.Text = order.Quantity.ToString();
            }
        }

        private void PlusQuantity(int amount)
        {
            order.Quantity++;
            textViewQuantity.Text = order.Quantity.ToString();
        }

        private void SetView()
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

    public class AdapterViewHolderCart : RecyclerView.ViewHolder
    {
        private ImageView imageViewIcon;

        private TextView textViewName;

        private TextView textViewPricePerUnit;

        private TextView textViewAmount;

        private TextView textViewPrice;

        private Order order;
        
        public Order Order
        {
            get => order;
            set
            {
                order = value;
                SetView();
            }
        }

        public AdapterViewHolderCart(View itemView) : base(itemView)
        {
            imageViewIcon = itemView.FindViewById<ImageView>(Resource.Id.image);
            textViewName = itemView.FindViewById<TextView>(Resource.Id.name);
            textViewAmount = itemView.FindViewById<TextView>(Resource.Id.tv_amount);
            textViewPricePerUnit = itemView.FindViewById<TextView>(Resource.Id.tv_priceperunit);
            textViewPrice = itemView.FindViewById<TextView>(Resource.Id.tv_value);
        }

        public void SetView()
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