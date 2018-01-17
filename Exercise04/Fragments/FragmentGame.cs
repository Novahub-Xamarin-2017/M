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
using Android.Support.V7.Widget;
using Exercise044.Adapters;
using Exercise044.Models;

namespace Exercise044.Fragments
{
    public class FragmentGame : Fragment
    {
        private readonly List<AppBookGame> games = new List<AppBookGame>()
        {
            new AppBookGame() {Name = "Game1", Info = "Info of Game1"},
            new AppBookGame() {Name = "Game2", Info = "Info of Game2"},
            new AppBookGame() {Name = "Game3", Info = "Info of Game3"},
            new AppBookGame() {Name = "Game4", Info = "Info of Game4"},
            new AppBookGame() {Name = "Game5", Info = "Info of Game5"},
            new AppBookGame() {Name = "Game6", Info = "Info of Game6"},
            new AppBookGame() {Name = "Game7", Info = "Info of Game7"},
            new AppBookGame() {Name = "Game8", Info = "Info of Game8"},
            new AppBookGame() {Name = "Game9", Info = "Info of Game9"},
            new AppBookGame() {Name = "Game10", Info = "Info of Game10"},
            new AppBookGame() {Name = "Game11", Info = "Info of Game11"},
            new AppBookGame() {Name = "Game12", Info = "Info of Game12"}
        };

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Fragment, container, false);

            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.rv_fragment);

            var layoutManager = new LinearLayoutManager(view.Context);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(new AdapterAppBookGame(games));

            return view;
        }
    }
}