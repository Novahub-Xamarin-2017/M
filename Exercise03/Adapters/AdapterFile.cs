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

        public List<File> Files
        {
            get => files;
            set
            {
                files = value;
            }
        }

        public event EventHandler<FileClickEventArgs> ItemClick;

        public AdapterFile(List<File> files)
        {
            this.files = files;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.CardView;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new FileViewHolder(itemView, OnClick);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((FileViewHolder)viewHolder).File = files[position];
        }

        public override int ItemCount => files.Count;

        private void OnClick(FileClickEventArgs args) => ItemClick?.Invoke(this.files, args);
    }

    public class FileViewHolder : RecyclerView.ViewHolder
    {
        private TextView textViewName;

        private ImageView imageViewIcon;

        public File File
        {
            set
            {
                textViewName.Text = value.Name;

                var id = (value.IsDirectory) ? Resource.Drawable.folder : Resource.Drawable.file;
                imageViewIcon.SetImageResource(id);
            }
        }

        public FileViewHolder(View itemView, Action<FileClickEventArgs> clickListener) : base(itemView)
        {
            textViewName = itemView.FindViewById<TextView>(Resource.Id.tv_name);
            imageViewIcon = itemView.FindViewById<ImageView>(Resource.Id.imv_icon);

            itemView.Click += delegate
            {
                clickListener(new FileClickEventArgs { View = itemView, Position = AdapterPosition });
            };
        }
    }

    public class FileClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}