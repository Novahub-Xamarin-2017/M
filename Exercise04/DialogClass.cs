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

namespace Exercise04
{
    class DialogClass : DialogFragment
    {
        private string info;

        public DialogClass(string info)
        {
            this.info = info;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Dialog, container, false);
            view.FindViewById<TextView>(Resource.Id.tv_dialog).Text = info;

            return view;
        }
    }
}