using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise01.CustomRecyclerView.Models;
using Android.Util;
using Android.Graphics;

namespace Exercise01.CustomRecyclerView
{
    class CustomAdapter : RecyclerView.Adapter
    {
        private List<AndroidVersion> androidVersions;

        public CustomAdapter(List<AndroidVersion> androidVersions)
        {
            this.androidVersions = androidVersions;
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
            ((CustomAdapterViewHolder)viewHolder).SetViewHolder(androidVersions[position]);
        }

        public override int ItemCount => androidVersions.Count;
    }

    public class CustomAdapterViewHolder : RecyclerView.ViewHolder
    {
        private ImageView ImageViewIcon;

        private TextView TextViewName;

        private TextView TextViewVersion;


        public CustomAdapterViewHolder(View itemView) : base(itemView)
        {
            ImageViewIcon = itemView.FindViewById<ImageView>(Resource.Id.image);
            TextViewName = itemView.FindViewById<TextView>(Resource.Id.name);
            TextViewVersion = itemView.FindViewById<TextView>(Resource.Id.version);
        }

        public void SetViewHolder(AndroidVersion androidVersion)
        {
            var imageAsBytes = Base64.Decode(androidVersion.Image, Base64Flags.Default);
            var imageAsBitmap = BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);

            ImageViewIcon.SetImageBitmap(imageAsBitmap);
            TextViewName.Text = androidVersion.Name;
            TextViewVersion.Text = androidVersion.Version;
        }
    }
}