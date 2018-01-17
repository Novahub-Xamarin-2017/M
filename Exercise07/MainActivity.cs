using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise07.Adapters;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Exercise07
{
    [Activity(Label = "Exercise07", Theme = "@android:style/Theme.Material.Light.DarkActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private MyAdapter adapter;

        private List<string> countrys;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            adapter = new MyAdapter();
            var input = Assets.Open("Countrys.json");

            using (var streamReader = new StreamReader(input))
            {
                var content = streamReader.ReadToEnd();
                countrys = JsonConvert.DeserializeObject<List<string>>(content);

                adapter = new MyAdapter(countrys);
            }

            recyclerView.SetAdapter(adapter);

            var searchView = FindViewById<SearchView>(Resource.Id.sv_country);

            searchView.QueryTextChange += delegate
            {
                adapter = new MyAdapter(countrys.Where(x => x.Contains(searchView.Query)).ToList());
                recyclerView.SetAdapter(adapter);
            };
        }
    }
}

