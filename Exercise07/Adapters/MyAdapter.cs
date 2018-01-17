using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Graphics;
using System.Collections.Generic;

namespace Exercise07.Adapters
{
    class MyAdapter : RecyclerView.Adapter
    {
        private List<string> items;

        public MyAdapter()
        {
        }

        public MyAdapter(List<string> countrys)
        {
            items = countrys;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.CardView;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new MyAdapterViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((MyAdapterViewHolder)viewHolder).SetViewHolder(items[position]);
        }

        public override int ItemCount => items.Count;
    }

    public class MyAdapterViewHolder : RecyclerView.ViewHolder
    {
        private TextView textViewCountry;

        public MyAdapterViewHolder(View itemView) : base(itemView)
        {
            textViewCountry = itemView.FindViewById<TextView>(Resource.Id.tv_country);

            itemView.Click += delegate 
            {
                Toast.MakeText(itemView.Context, textViewCountry.Text, ToastLength.Short).Show();
            };
        }

        public void SetViewHolder(string country)
        {
            textViewCountry.Text = country;

            if (country.Length == 1)
            {
                textViewCountry.SetTextColor(Color.Red);
                textViewCountry.SetBackgroundColor(Color.Blue);
            } else
            {
                textViewCountry.SetTextColor(Color.Black);
                textViewCountry.SetBackgroundColor(Color.White);
            }
        }
    }
}