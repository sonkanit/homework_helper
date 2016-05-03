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

namespace homework_helper
{
    class QuestionHeaderAdapter : BaseAdapter<Question>
    {
        Activity activity;
        int layoutResourceId;
        List<Question> questions = new List<Question>();

        public QuestionHeaderAdapter(Activity activity, int layoutResourceId)
        {
            this.activity = activity;
            this.layoutResourceId = layoutResourceId;
        }

        public override Question this[int position]
        {
            get
            {
                return questions[position];
            }
        }

        public override int Count
        {
            get
            {
                return questions.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;
            var currentItem = this[position];

            TextView text, author, point;
            if (row == null)
            {
                var inflator = activity.LayoutInflater;
                row = inflator.Inflate(layoutResourceId, parent, false);
            }

            text = row.FindViewById<TextView>(Resource.Id.textQuestionHeader);
            author = row.FindViewById<TextView>(Resource.Id.textQuestionAuthor);
            point = row.FindViewById<TextView>(Resource.Id.textQuestionPoint);
            text.Click += OnHeaderClick;
            text.Text = currentItem.Text;
            point.Text = currentItem.Point.ToString();
            author.Text = "TODO:Author";
            return row;
        }

        private void OnHeaderClick(object sender, EventArgs e)
        {
            ((QuestionListActivity)activity).ViewQuestionPage();
        }
    }
}