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
    public class FragmentBook : Fragment
    {
        private readonly List<AppBookGame> books = new List<AppBookGame>()
        {
            new AppBookGame() {Name = "Book1", Info = "Info of Book1"},
            new AppBookGame() {Name = "Book2", Info = "Info of Book2"},
            new AppBookGame() {Name = "Book3", Info = "Info of Book3"},
            new AppBookGame() {Name = "Book4", Info = "Info of Book4"},
            new AppBookGame() {Name = "Book5", Info = "Info of Book5"},
            new AppBookGame() {Name = "Book6", Info = "Info of Book6"},
            new AppBookGame() {Name = "Book7", Info = "Info of Book7"},
            new AppBookGame() {Name = "Book8", Info = "Info of Book8"},
            new AppBookGame() {Name = "Book9", Info = "Info of Book9"},
            new AppBookGame() {Name = "Book10", Info = "Info of Book10"},
            new AppBookGame() {Name = "Book11", Info = "Info of Book11"},
            new AppBookGame() {Name = "Book12", Info = "Info of Book12"}
        };

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Fragment, container, false);

            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.rv_fragment);

            var layoutManager = new LinearLayoutManager(view.Context);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(new AdapterAppBookGame(books));

            return view;
        }
    }
}