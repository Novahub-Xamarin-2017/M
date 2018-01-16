using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise05.Models;
using Android.Graphics;
using Android.App;

namespace Exercise05.Adapters
{
    class MyAdapter : RecyclerView.Adapter
    {
        private List<Task> items;

        public MyAdapter(List<Task> items)
        {
            this.items = items;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.CardView;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new MyAdapterViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((MyAdapterViewHolder)viewHolder).SetMyViewHolder(items[position]);
        }

        public override int ItemCount => items.Count;
    }

    public class MyAdapterViewHolder : RecyclerView.ViewHolder
    {
        private View viewLine;

        private TextView textViewProject;

        private TextView textViewExercise;

        private TextView textViewTopic;

        private TextView textViewDate;

        private TextView textViewTime;

        private Button buttonDayLeft;

        private Button buttonResumeOrReport;

        private ImageButton imageButtonSetting;

        public MyAdapterViewHolder(View itemView) : base(itemView)
        {
            viewLine = itemView.FindViewById<View>(Resource.Id.v_line);

            textViewProject = itemView.FindViewById<TextView>(Resource.Id.tv_name_project);
            textViewExercise = itemView.FindViewById<TextView>(Resource.Id.tv_name_exercise);
            textViewTopic = itemView.FindViewById<TextView>(Resource.Id.tv_description);
            textViewDate = itemView.FindViewById<TextView>(Resource.Id.tv_date);
            textViewTime = itemView.FindViewById<TextView>(Resource.Id.tv_time);

            buttonDayLeft = itemView.FindViewById<Button>(Resource.Id.btn_dayleft);
            buttonResumeOrReport = itemView.FindViewById<Button>(Resource.Id.btn_re);

            imageButtonSetting = itemView.FindViewById<ImageButton>(Resource.Id.im_btn_setting);

            itemView.Click += delegate
            {
                var transcation = ((Activity)itemView.Context).FragmentManager.BeginTransaction();
                var signup = new DialogClass($"Detail of {textViewProject.Text} {textViewExercise.Text}");
                signup.Show(transcation, "Dialog Fragment");
            };
        }

        public void SetMyViewHolder(Task task)
        {
            textViewProject.Text = task.Project;
            textViewExercise.Text = task.Exercise;
            textViewTopic.Text = task.Topic;
            textViewDate.Text = task.Date.ToString("dd/MM/yyyy");
            textViewTime.Text = task.Time.ToString();

            if (task.DayLeft == 0)
            {
                buttonDayLeft.Text = "COMPLETED";
                buttonDayLeft.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.complete, 0, 0, 0);

                buttonResumeOrReport.Text = "REPORT";
                buttonResumeOrReport.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.report, 0, 0, 0);
            } else
            {
                viewLine.SetBackgroundColor(Color.Red);

                buttonDayLeft.Text = $"{task.DayLeft} DAYs LEFT";
                buttonDayLeft.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.warning, 0, 0, 0);

                buttonResumeOrReport.Text = "RESUME";
                buttonResumeOrReport.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.resume, 0, 0, 0);
            }
        }
    }
}