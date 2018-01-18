using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise07.Adapters;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Exercise07.Models;

namespace Exercise07
{
    [Activity(Label = "Exercise07", Theme = "@android:style/Theme.Material.Light.DarkActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private CountryAdapter adapter;

        private List<object> countries;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            var input = Assets.Open("Countries.json");

            using (var streamReader = new StreamReader(input))
            {
                var content = streamReader.ReadToEnd();
                countries = JsonConvert.DeserializeObject<List<Country>>(content)
                    .GroupBy(x => x.Name.First())
                    .Select(x => new List<object>() { x.Key.ToString() }.Union(x))
                    .SelectMany(x => x)
                    .ToList();

                adapter = new CountryAdapter(countries);
            }

            recyclerView.SetAdapter(adapter);
            adapter.NotifyDataSetChanged();

            var searchView = FindViewById<SearchView>(Resource.Id.sv_country);

            searchView.QueryTextChange += delegate
            {
                adapter.Countries = countries.Where(x => x is Country ? ((Country)x).Name.Contains(searchView.Query) : x.ToString().Contains(searchView.Query))
                    .ToList<object>(); ;
                recyclerView.SetAdapter(adapter);
            };
        }
    }
}
