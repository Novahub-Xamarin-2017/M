using Android.App;
using Android.Widget;
using Android.OS;
using Exercise04.Adapters;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise04.Models;

namespace Exercise04
{
    [Activity(Label = "Exercise04", Theme = "@android:style/Theme.Material.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private MyAdapter adapter;

        private readonly List<Item> apps = new List<Item>()
        {
            new Item() {Name = "App1", Info = "Info of App1"},
            new Item() {Name = "App2", Info = "Info of App2"},
            new Item() {Name = "App3", Info = "Info of App3"},
            new Item() {Name = "App4", Info = "Info of App4"},
            new Item() {Name = "App5", Info = "Info of App5"},
            new Item() {Name = "App6", Info = "Info of App6"},
            new Item() {Name = "App7", Info = "Info of App7"},
            new Item() {Name = "App8", Info = "Info of App8"},
            new Item() {Name = "App9", Info = "Info of App9"},
            new Item() {Name = "App10", Info = "Info of App10"},
            new Item() {Name = "App11", Info = "Info of App11"},
            new Item() {Name = "App12", Info = "Info of App12"}
         };

        private readonly List<Item> books = new List<Item>()
        {
            new Item() {Name = "Book1", Info = "Info of Book1"},
            new Item() {Name = "Book2", Info = "Info of Book2"},
            new Item() {Name = "Book3", Info = "Info of Book3"},
            new Item() {Name = "Book4", Info = "Info of Book4"},
            new Item() {Name = "Book5", Info = "Info of Book5"},
            new Item() {Name = "Book6", Info = "Info of Book6"},
            new Item() {Name = "Book7", Info = "Info of Book7"},
            new Item() {Name = "Book8", Info = "Info of Book8"},
            new Item() {Name = "Book9", Info = "Info of Book9"},
            new Item() {Name = "Book10", Info = "Info of Book10"},
            new Item() {Name = "Book11", Info = "Info of Book11"},
            new Item() {Name = "Book12", Info = "Info of Book12"}
        };

        private readonly List<Item> games = new List<Item>()
        {
            new Item() {Name = "Game1", Info = "Info of Game1"},
            new Item() {Name = "Game2", Info = "Info of Game2"},
            new Item() {Name = "Game3", Info = "Info of Game3"},
            new Item() {Name = "Game4", Info = "Info of Game4"},
            new Item() {Name = "Game5", Info = "Info of Game5"},
            new Item() {Name = "Game6", Info = "Info of Game6"},
            new Item() {Name = "Game7", Info = "Info of Game7"},
            new Item() {Name = "Game8", Info = "Info of Game8"},
            new Item() {Name = "Game9", Info = "Info of Game9"},
            new Item() {Name = "Game10", Info = "Info of Game10"},
            new Item() {Name = "Game11", Info = "Info of Game11"},
            new Item() {Name = "Game12", Info = "Info of Game12"}
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.rccview_main);
            
            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            
            adapter = new MyAdapter(apps);
            recyclerView.SetAdapter(adapter);

            FindViewById<Button>(Resource.Id.btn_app).Click += delegate
            {
                adapter = new MyAdapter(apps);
                recyclerView.SetAdapter(adapter);
            };

            FindViewById<Button>(Resource.Id.btn_book).Click += delegate
            {
                adapter = new MyAdapter(books);
                recyclerView.SetAdapter(adapter);
            };

            FindViewById<Button>(Resource.Id.btn_game).Click += delegate
            {
                adapter = new MyAdapter(games);
                recyclerView.SetAdapter(adapter);
            };
        }
    }
}

