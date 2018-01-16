using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise05.Adapters;
using System.Collections.Generic;
using Exercise05.Models;
using System;

namespace Exercise05
{
    [Activity(Label = "Exercise05", Theme = "@android:style/Theme.Material.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);
            
            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            var tasks = new List<Task>()
            {
                new Task()
                {
                    Project = "CS-101 Python,",
                    Exercise = "Exercise 1",
                    Topic = "Data Structures 1",
                    Date = new DateTime(2018, 1, 4),
                    DayLeft = 3,
                    Time = 30
                },
                new Task()
                {
                    Project = "CS-101 Python,",
                    Exercise = "Exercise 2",
                    Topic = "Data Structures 2",
                    Date = new DateTime(2018, 1, 3),
                    DayLeft = 2,
                    Time = 35
                },
                new Task()
                {
                    Project = "CS-101 Python,",
                    Exercise = "Exercise 3",
                    Topic = "Data Structures 3",
                    Date = new DateTime(2018, 1, 2),
                    DayLeft = 1,
                    Time = 40
                },
                new Task()
                {
                    Project = "CS-101 Python,",
                    Exercise = "Exercise 4",
                    Topic = "Data Structures 4",
                    Date = new DateTime(2018, 1, 1),
                    DayLeft = 0,
                    Time = 45
                }
            };

            var adapter = new MyAdapter(tasks);
            recyclerView.SetAdapter(adapter);
        }
    }
}

