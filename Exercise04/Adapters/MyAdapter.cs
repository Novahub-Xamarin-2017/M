using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise04.Models;
using Android.App;

namespace Exercise04.Adapters
{
    class MyAdapter : RecyclerView.Adapter
    {
        private List<Item> items;

        public MyAdapter(List<Item> items)
        {
            this.items = items;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here

            var id = Resource.Layout.CardView;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new MyAdapterViewHolder(itemView);
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = (MyAdapterViewHolder)viewHolder;

            holder.TextViewName.Text = item.Name;
            holder.Info = item.Info;
        }

        public override int ItemCount => items.Count;
    }

    public class MyAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView TextViewName { get; set; }

        public string Info { get; set; }

        public MyAdapterViewHolder(View itemView) : base(itemView)
        {
            TextViewName = itemView.FindViewById<TextView>(Resource.Id.tv_name);

            itemView.Click += delegate
            {
                FragmentTransaction transcation = ((Activity)itemView.Context).FragmentManager.BeginTransaction();
                DialogClass signup = new DialogClass(Info);
                signup.Show(transcation, "Dialog Fragment");
            };
        }
    }
}