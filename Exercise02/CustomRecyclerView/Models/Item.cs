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
    class Item
    {
        public String Name { set; get; }

        public String PricePerUnit { set; get; }

        public String Unit { set; get; }

        public String Image { set; get; }

        public String Value { set; get; } = "0";
    }

    class Items
    {
        public static List<Item> ListOfItem { set; get; } = new List<Item>();

        Items()
        {
            ListOfItem = new List<Item>();
        }
    }
}