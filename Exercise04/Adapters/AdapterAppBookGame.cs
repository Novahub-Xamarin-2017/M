using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise044.Models;
using Android.App;

namespace Exercise044.Adapters
{
    class AdapterAppBookGame : RecyclerView.Adapter
    {
        private List<AppBookGame> AppBookGames;

        public AdapterAppBookGame(List<AppBookGame> AppBookGames)
        {
            this.AppBookGames = AppBookGames;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.CardView;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new AdapterViewHolderAppBookGames(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((AdapterViewHolderAppBookGames)viewHolder).AppBookGame = AppBookGames[position];
        }

        public override int ItemCount => AppBookGames.Count;
    }

    public class AdapterViewHolderAppBookGames : RecyclerView.ViewHolder
    {
        private TextView TextViewName;

        private AppBookGame appBookGame;

        public AppBookGame AppBookGame
        {
            get => appBookGame;
            set
            {
                appBookGame = value;

                TextViewName.Text = value.Name;
            }
        }

        public AdapterViewHolderAppBookGames(View itemView) : base(itemView)
        {
            TextViewName = itemView.FindViewById<TextView>(Resource.Id.tv_name);

            itemView.Click += delegate
            {
                var transcation = ((Activity)itemView.Context).FragmentManager.BeginTransaction();
                var signup = new DialogClass(appBookGame.Info);
                signup.Show(transcation, "Dialog Fragment");
            };
        }
    }
}