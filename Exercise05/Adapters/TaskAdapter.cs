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
    class TaskAdapter : RecyclerView.Adapter
    {
        private List<Task> tasks;

        public TaskAdapter(List<Task> tasks)
        {
            this.tasks = tasks;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.CardView;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new TaskViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((TaskViewHolder)viewHolder).Task = tasks[position];
        }

        public override int ItemCount => tasks.Count;
    }

    public class TaskViewHolder : RecyclerView.ViewHolder
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

        private Task task;

        public Task Task
        {
            get => task;
            set
            {
                task = value;
                SetView();
            }
        }

        public TaskViewHolder(View itemView) : base(itemView)
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

        public void SetView()
        {
            textViewProject.Text = task.Project;
            textViewExercise.Text = task.Exercise;
            textViewTopic.Text = task.Topic;
            textViewDate.Text = task.Date.ToString("dd/MM/yyyy");
            textViewTime.Text = task.Time.ToString();

            if (task.DayLeft == 0)
            {
                SetDrawablesAndLineColor(Color.Blue, "COMPLETED", Resource.Drawable.complete, "REPORT", Resource.Drawable.report);
            }
            else
            {
                SetDrawablesAndLineColor(Color.Red, $"{task.DayLeft} DAYs LEFT", Resource.Drawable.warning, "RESUME", Resource.Drawable.resume);
            }
        }

        public void SetDrawablesAndLineColor(Color color, string textOfButtonDayLeft, int resourceDrawableOfButtonDayLeft, string textOfButtonResumeOrReport, int resourceDrawableOfButtonResumeOrReport)
        {
            viewLine.SetBackgroundColor(color);

            buttonDayLeft.Text = textOfButtonDayLeft;
            buttonDayLeft.SetCompoundDrawablesWithIntrinsicBounds(resourceDrawableOfButtonDayLeft, 0, 0, 0);

            buttonResumeOrReport.Text = textOfButtonResumeOrReport;
            buttonResumeOrReport.SetCompoundDrawablesWithIntrinsicBounds(resourceDrawableOfButtonResumeOrReport, 0, 0, 0);
        }
    }
}