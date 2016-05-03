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
    [Activity(Label = "SelectPathActivity", Theme = "@android:style/Theme.Black.NoTitleBar")]
    public class SelectPathActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SelectPath);
            var btnAsk = FindViewById<Button>(Resource.Id.buttonAskPath);
            var btnAnswer = FindViewById<Button>(Resource.Id.buttonAnswerPath);
            var linkQuestionList = FindViewById<TextView>(Resource.Id.textViewQuestions);
            linkQuestionList.Click += OnLinkQuestionListClick;
        }

        private void OnLinkQuestionListClick(object sender, EventArgs e)
        {
            var intent = new Intent(this.ApplicationContext, typeof(QuestionListActivity));
            StartActivity(intent);
        }
    }
}