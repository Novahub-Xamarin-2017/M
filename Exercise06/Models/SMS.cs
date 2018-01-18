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

namespace Exercise06.Models
{
    public class SMS
    {
        public string Name { set; get; }

        public string Message { set; get; }

        public DateTime Time { set; get; }
    }
}