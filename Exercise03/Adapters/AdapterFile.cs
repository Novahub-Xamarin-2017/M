using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Content;
using Exercise03;
using Java.IO;
using System.IO;
using File = Java.IO.File;

namespace Exercise03.Adapters
{
    class AdapterFile : RecyclerView.Adapter
    {
        List<File> items;

        public AdapterFile(List<File> data)
        {
            items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            
            var id = Resource.Layout.CardView;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new FileViewHolder(itemView);
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as FileViewHolder;

            holder.TextViewName.Text = item.Name;
            holder.MyFile = item;

            var id = (item.IsDirectory) ? Resource.Drawable.folder : Resource.Drawable.file;
            holder.ImageViewIcon.SetImageResource(id);
        }

        public override int ItemCount => items.Count;
    }

    public class FileViewHolder : RecyclerView.ViewHolder
    {
        private readonly List<string> videoExtensions = new List<string>() { ".mp3", ".mp4", ".flv", ".3gp" };

        private readonly List<string> imageExtensions = new List<string>() { ".jpg", ".png" };

        public TextView TextViewName { get; set; }

        public ImageView ImageViewIcon { get; set; }

        public File MyFile { get; set; }

        public FileViewHolder(View itemView) : base(itemView)
        {
            TextViewName = itemView.FindViewById<TextView>(Resource.Id.tv_name);
            ImageViewIcon = itemView.FindViewById<ImageView>(Resource.Id.imv_icon);

            itemView.Click += delegate
            {
                if (MyFile.IsDirectory)
                {
                    MainActivity.UpDateData(MainActivity.pathDir + "/" + TextViewName.Text);
                }
                else
                {
                    if (imageExtensions.Contains(Path.GetExtension(MyFile.Path)))
                    {
                        var intent = new Intent(itemView.Context, typeof(Image));
                        intent.PutExtra("path", MyFile.Path);
                        ItemView.Context.StartActivity(intent);
                    }
                    else if (videoExtensions.Contains(Path.GetExtension(MyFile.Path)))
                    {
                        var intent = new Intent(itemView.Context, typeof(Video));
                        intent.PutExtra("path", MyFile.Path);
                        ItemView.Context.StartActivity(intent);
                    }
                    else
                    {
                        Toast.MakeText(itemView.Context, MainActivity.pathDir + "/" + TextViewName.Text, ToastLength.Short).Show();
                    }
                }
            };
        }
    }
}