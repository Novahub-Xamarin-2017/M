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
using Android.App;

namespace Exercise03.Adapters
{
    class AdapterFile : RecyclerView.Adapter
    {
        private List<File> files;

        private TextView textViewPath;

        public AdapterFile(List<File> files, TextView textViewPath)
        {
            this.files = files;
            this.textViewPath = textViewPath;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.CardView;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new FileViewHolder(itemView, textViewPath);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((FileViewHolder)viewHolder).File = files[position];
        }

        public override int ItemCount => files.Count;
    }

    public class FileViewHolder : RecyclerView.ViewHolder
    {
        private readonly List<string> videoExtensions = new List<string>() { ".mp3", ".mp4", ".flv", ".3gp" };

        private readonly List<string> imageExtensions = new List<string>() { ".jpg", ".png" };

        private TextView textViewName;

        private ImageView imageViewIcon;

        private File file;

        public File File
        {
            get => file;
            set
            {
                textViewName.Text = value.Name;
                file = value;

                var id = (value.IsDirectory) ? Resource.Drawable.folder : Resource.Drawable.file;
                imageViewIcon.SetImageResource(id);
            }
        }

        public FileViewHolder(View itemView, TextView textViewPath) : base(itemView)
        {
            textViewName = itemView.FindViewById<TextView>(Resource.Id.tv_name);
            imageViewIcon = itemView.FindViewById<ImageView>(Resource.Id.imv_icon);

            itemView.Click += delegate
            {
                if (file.IsDirectory)
                {
                    textViewPath.Text = file.Path;
                }
                else
                {
                    if (IsImageExtensions(file))
                    {
                        var intent = new Intent(itemView.Context, typeof(Image));
                        intent.PutExtra("path", file.Path);
                        ItemView.Context.StartActivity(intent);
                    }
                    else if (IsVideoExtensions(file))
                    {
                        var intent = new Intent(itemView.Context, typeof(Video));
                        intent.PutExtra("path", file.Path);
                        ItemView.Context.StartActivity(intent);
                    }
                    else
                    {
                        Toast.MakeText(itemView.Context, file.Path, ToastLength.Short).Show();
                    }
                }
            };
        }

        public bool IsImageExtensions(File file) => imageExtensions.Contains(Path.GetExtension(file.Path));

        public bool IsVideoExtensions(File file) => videoExtensions.Contains(Path.GetExtension(file.Path));
    }
}