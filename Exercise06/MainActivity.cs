using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise06.Models;
using Exercise06.Adapters;
using System;

namespace Exercise06
{
    [Activity(Label = "Exercise06", Theme = "@android:style/Theme.Material.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            var tasks = new List<object>()
            {
                new Call()
                {
                    Name = "Person 1",
                    Time = new DateTime(2018,1,1,9,15,00)
                },
                new SMS()
                {
                    Name = "Person 2",
                    Message = "Message 2",
                    Time = new DateTime(2018,1,1,9,20,00)
                },
                new Call()
                {
                    Name = "Person 3",
                    Time = new DateTime(2018,1,1,9,25,00)
                },
                new SMS()
                {
                    Name = "Person 4",
                    Message = "Message 4",
                    Time = new DateTime(2018,1,1,9,30,00)
                },
                new Call()
                {
                    Name = "Person 1",
                    Time = new DateTime(2018,1,1,9,15,00)
                },
                new SMS()
                {
                    Name = "Person 2",
                    Message = "Message 2",
                    Time = new DateTime(2018,1,1,9,20,00)
                },
                new Call()
                {
                    Name = "Person 3",
                    Time = new DateTime(2018,1,1,9,25,00)
                },
                new SMS()
                {
                    Name = "Person 4",
                    Message = "Message 4",
                    Time = new DateTime(2018,1,1,9,30,00)
                }
            };

            var adapter = new MyAdapter(tasks);
            recyclerView.SetAdapter(adapter);
        }
    }
}

