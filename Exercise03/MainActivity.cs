using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise03.Adapters;
using System.Collections.Generic;
using Java.IO;
using System.Linq;
using Android.Content;
using File = Java.IO.File;
using System.IO;
using Android.Views;

namespace Exercise03
{
    [Activity(Label = "Exercise03", Theme = "@android:style/Theme.Material.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private readonly List<string> videoExtensions = new List<string>() { ".mp3", ".mp4", ".flv", ".3gp" };

        private readonly List<string> imageExtensions = new List<string>() { ".jpg", ".png" };

        private TextView textViewPath;

        private RecyclerView recyclerView;

        private AdapterFile adapter;

        private readonly string root = Environment.GetExternalStoragePublicDirectory("/").Path;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            textViewPath = FindViewById<TextView>(Resource.Id.tv_path);
            textViewPath.Text = root;
            textViewPath.TextChanged += delegate
            {
                UpDateData(textViewPath.Text);
            };

            FindViewById<ImageButton>(Resource.Id.im_btn_back).Click += delegate
            {
                if (!textViewPath.Text.Equals(root))
                {
                    textViewPath.Text = Path.GetDirectoryName(textViewPath.Text);
                }
            };

            var filesOrNull = (new File(root)).ListFiles();
            var files = filesOrNull?.ToList() ?? new List<File>();
            adapter = new AdapterFile(files, textViewPath);
            recyclerView.SetAdapter(adapter);

            adapter.NotifyDataSetChanged();

            /*adapter.OnClick += delegate
            {

            };

            adapter.onc*/

            adapter.ItemClick += (object sender, FileClickEventArgs e) =>
            {
                var file = adapter.Files[e.Position];

                if (file.IsDirectory)
                {
                    textViewPath.Text = file.Path;
                }
                else
                {
                    if (IsImageExtensions(file))
                    {
                        var intent = new Intent(this, typeof(Image));
                        intent.PutExtra("path", file.Path);
                        StartActivity(intent);
                    }
                    else if (IsVideoExtensions(file))
                    {
                        var intent = new Intent(this, typeof(Video));
                        intent.PutExtra("path", file.Path);
                        StartActivity(intent);
                    }
                    else
                    {
                        Toast.MakeText(this, file.Path, ToastLength.Short).Show();
                    }
                }
            };
        }

        private bool IsImageExtensions(File file) => imageExtensions.Contains(Path.GetExtension(file.Path.ToLower()));

        private bool IsVideoExtensions(File file) => videoExtensions.Contains(Path.GetExtension(file.Path.ToLower()));

        private void UpDateData(string path)
        {
            var filesOrNull = (new File(path)).ListFiles();
            var files = filesOrNull?.ToList()?? new List<File>();
            adapter.Files = files;
            recyclerView.SetAdapter(adapter);
        }
    }
}