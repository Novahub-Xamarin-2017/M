using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Graphics;
using System.Collections.Generic;
using Exercise07.Models;

namespace Exercise07.Adapters
{
    class CountryAdapter : RecyclerView.Adapter
    {
        private const int countryType = 1;

        private List<object> countries;

        public List<object> Countries
        {
            set
            {
                countries = value;
            }
        }

        public CountryAdapter(List<object> countries)
        {
            this.countries = countries;
        }

        public override int GetItemViewType(int position)
        {
            if (countries[position] is Country)
            {
                return countryType;
            }
            else
            {
                return -1;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == countryType)
            {
                var id = Resource.Layout.CardViewCountry;
                var itemView = LayoutInflater.From(parent.Context).
                       Inflate(id, parent, false);

                return new CountryAdapterViewHolder(itemView);
            } else
            {
                var id = Resource.Layout.CardView;
                var itemView = LayoutInflater.From(parent.Context).
                       Inflate(id, parent, false);

                return new CountryAdapterViewHolder(itemView);
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            if (countries[position] is Country)
            {
                ((CountryAdapterViewHolder)viewHolder).Country = (Country)countries[position];
            }
            else
            {
                ((CountryAdapterViewHolder)viewHolder).Header = countries[position].ToString();
            }
        }

        public override int ItemCount => countries.Count;
    }

    public class CountryAdapterViewHolder : RecyclerView.ViewHolder
    {
        private TextView textViewCountry;

        private Country country;

        public Country Country
        {
            get => country;
            set
            {
                country = value;

                textViewCountry.Text = value.Name;
            }
        }

        private string header;

        public string Header
        {
            get => header;
            set
            {
                header = value;

                textViewCountry.Text = value;
            }
        }

        public CountryAdapterViewHolder(View itemView) : base(itemView)
        {
            textViewCountry = itemView.FindViewById<TextView>(Resource.Id.tv_country);

            itemView.Click += delegate 
            {
                Toast.MakeText(itemView.Context, textViewCountry.Text, ToastLength.Short).Show();
            };
        }
    }
}