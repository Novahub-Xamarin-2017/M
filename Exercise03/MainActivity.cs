using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise03.Adapters;
using System.Collections.Generic;
using Java.IO;
using System.Linq;
using System.IO;
using Android.Content;
using File = Java.IO.File;

namespace Exercise03
{
    [Activity(Label = "Exercise03", Theme = "@android:style/Theme.Material.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private TextView textViewPath;

        private RecyclerView recyclerView;

        private AdapterFile adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            FindViewById<ImageButton>(Resource.Id.im_btn_back).Click += delegate
            {
                var path = textViewPath.Text;

                if (!path.Equals(Environment.GetExternalStoragePublicDirectory("/").Path))
                {
                    textViewPath.Text = path.Substring(0, !path.Contains('/') ? 0 : path.LastIndexOf('/'));
                }
            };

            textViewPath = FindViewById<TextView>(Resource.Id.tv_path);

            textViewPath.TextChanged += delegate
            {
                UpDateData(textViewPath.Text);
            };

            textViewPath.Text = Environment.GetExternalStoragePublicDirectory("/").Path;
        }

        public void UpDateData(string path)
        {
            var filesOrNull = (new File(path)).ListFiles();
            var files = filesOrNull != null ? filesOrNull.ToList() : new List<File>();

            adapter = new AdapterFile(files, textViewPath);
            recyclerView.SetAdapter(adapter);
        }
    }
}