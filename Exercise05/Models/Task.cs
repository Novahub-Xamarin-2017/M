using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Exercise05.Models
{
    public class Task
    {
        public string Project { get; set; }

        public string Exercise { get; set; }

        public string Topic { get; set; }

        public DateTime Date { get; set; }

        public int Time { get; set; }

        public int DayLeft { get; set; }
    }
}