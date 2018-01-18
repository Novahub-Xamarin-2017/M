using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Exercise044.Models;
using Android.Support.V7.Widget;
using Exercise044.Adapters;

namespace Exercise044.Fragments
{
    public class FragmentApp : Fragment
    {
        private readonly List<AppBookGame> apps = new List<AppBookGame>()
        {
            new AppBookGame() {Name = "App1", Info = "Info of App1"},
            new AppBookGame() {Name = "App2", Info = "Info of App2"},
            new AppBookGame() {Name = "App3", Info = "Info of App3"},
            new AppBookGame() {Name = "App4", Info = "Info of App4"},
            new AppBookGame() {Name = "App5", Info = "Info of App5"},
            new AppBookGame() {Name = "App6", Info = "Info of App6"},
            new AppBookGame() {Name = "App7", Info = "Info of App7"},
            new AppBookGame() {Name = "App8", Info = "Info of App8"},
            new AppBookGame() {Name = "App9", Info = "Info of App9"},
            new AppBookGame() {Name = "App10", Info = "Info of App10"},
            new AppBookGame() {Name = "App11", Info = "Info of App11"},
            new AppBookGame() {Name = "App12", Info = "Info of App12"}
        };

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Fragment, container, false);

            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.rv_fragment);

            var layoutManager = new LinearLayoutManager(view.Context);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(new AdapterAppBookGame(apps));

            return view;
        }
    }
}