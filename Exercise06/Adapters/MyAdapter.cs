using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise06.Models;

namespace Exercise06.Adapters
{
    class MyAdapter : RecyclerView.Adapter
    {
        private const int CallType = 1;

        private const int SMSType = 2;

        private List<object> items;

        public MyAdapter(List<object> items)
        {
            this.items = items;
        }

        public override int GetItemViewType(int position)
        {
            if (items[position] is Call) {
                return CallType;
            } else if (items[position] is SMS) {
                return SMSType;
            }

            return -1;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == CallType)
            {
                var id = Resource.Layout.CardViewCall;
                var itemView = LayoutInflater.From(parent.Context).
                       Inflate(id, parent, false);

                return new MyAdapterViewHolderCall(itemView);
            } else if (viewType == SMSType)
            {
                var id = Resource.Layout.CardViewSMS;
                var itemView = LayoutInflater.From(parent.Context).
                       Inflate(id, parent, false);

                return new MyAdapterViewHolderSMS(itemView);
            }

            return null;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            if (viewHolder is MyAdapterViewHolderCall)
            {
                ((MyAdapterViewHolderCall)viewHolder).SetViewHolerCall((Call)items[position]);
            }
            else if (viewHolder is MyAdapterViewHolderSMS)
            {
                ((MyAdapterViewHolderSMS)viewHolder).SetViewHolerSMS((SMS)items[position]);
            }
        }

        public override int ItemCount => items.Count;
    }

    public class MyAdapterViewHolderCall : RecyclerView.ViewHolder
    {
        private TextView TextViewName;

        private TextView TextViewTime;

        public MyAdapterViewHolderCall(View itemView) : base(itemView)
        {
            TextViewName = itemView.FindViewById<TextView>(Resource.Id.tv_name);
            TextViewTime = itemView.FindViewById<TextView>(Resource.Id.tv_time);
        }

        public void SetViewHolerCall(Call call)
        {
            TextViewName.Text = call.Name;
            TextViewTime.Text = call.Time.ToLongTimeString();
        }
    }

    public class MyAdapterViewHolderSMS : RecyclerView.ViewHolder
    {
        private TextView TextViewName;

        private TextView TextViewMessage;

        private TextView TextViewTime;

        public MyAdapterViewHolderSMS(View itemView) : base(itemView)
        {
            TextViewName = itemView.FindViewById<TextView>(Resource.Id.tv_name);
            TextViewMessage = itemView.FindViewById<TextView>(Resource.Id.tv_message);
            TextViewTime = itemView.FindViewById<TextView>(Resource.Id.tv_time);
        }

        public void SetViewHolerSMS(SMS sms)
        {
            TextViewName.Text = sms.Name;
            TextViewMessage.Text = sms.Message;
            TextViewTime.Text = sms.Time.ToLongTimeString();
        }
    }
}