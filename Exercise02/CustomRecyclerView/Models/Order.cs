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

namespace Exercise02.CustomRecyclerView.Models
{
    public class Order
    {
        public String Name { set; get; }

        public int PricePerUnit { set; get; }

        public String Unit { set; get; }

        public String Image { set; get; }

        public int Quantity { set; get; } = 0;
    }
}