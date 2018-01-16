using Android.App;
using Android.Widget;
using Android.OS;
using Exercise044.Adapters;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise044.Models;

namespace Exercise044
{
    [Activity(Label = "Exercise04", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private MyAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.rccview_main);
            
            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            var items = new List<Item>()
            {
                new Item() {Name = "App1", Info = "Info of App1"},
                new Item() {Name = "App2", Info = "Info of App2"},
                new Item() {Name = "App3", Info = "Info of App3"},
                new Item() {Name = "App4", Info = "Info of App4"}
            };
            
            adapter = new MyAdapter(items);
            
            recyclerView.SetAdapter(adapter);

            /*FindViewById<Button>(Resource.Id.btn_app).Click += delegate
            {
                var fragment = new Fragment1();
                //fragment.View.Contex
                var fm = this.FragmentManager;
                var ft = fm.BeginTransaction();
                //var q = FragmentManager.FindFragmentById<Fragment1>(Resource.Id.my_fragment);
                //ft.Remove(q);
                ft.Replace(Resource.Id.my_fragment2, fragment);
                ft.Commit();
                //FindViewById<TextView>(Resource.Id.tv_name).Text = "1";
            };

            FindViewById<Button>(Resource.Id.btn_book).Click += delegate
            {
                var fragment = new Fragment2();
                var fm = this.FragmentManager;
                var ft = fm.BeginTransaction();
                ft.Replace(Resource.Id.my_fragment2, fragment);
                ft.Commit();
                //FindViewById<TextView>(Resource.Id.tv_book).Text = "2";
            };

            FindViewById<Button>(Resource.Id.btn_game).Click += delegate
            {
                var fragment = new Fragment1();
                var fm = this.FragmentManager;
                var ft = fm.BeginTransaction();
                ft.Replace(Resource.Id.my_fragment, fragment);
                ft.Commit();
                //FindViewById<TextView>(Resource.Id.tv_name).Text = "3";
            };*/
        }
    }
}

