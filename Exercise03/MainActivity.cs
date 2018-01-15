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
        public static RecyclerView recyclerView;

        public static string pathDir = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            FindViewById<ImageButton>(Resource.Id.im_btn_back).Click += delegate
            {
                pathDir = pathDir.Substring(0, pathDir.LastIndexOf('/') == -1 ? 0 : pathDir.LastIndexOf('/'));
                UpDateData(pathDir);
            };

            UpDateData("/");
        }

        public static void UpDateData(string path)
        {
            pathDir = path;

            var files = new List<File>();

            var dir = Environment.GetExternalStoragePublicDirectory(path);
            var list = dir.ListFiles();

            if (list != null)
            {
                files.AddRange(list);
            }

            var adapter = new AdapterFile(files);
            recyclerView.SetAdapter(adapter);
        }
    }
}