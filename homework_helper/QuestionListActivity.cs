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
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace homework_helper
{
    [Activity(Label = "QuestionListActivity", Theme = "@android:style/Theme.Black.NoTitleBar")]
    public class QuestionListActivity : Activity
    {
        QuestionHeaderAdapter adapter;
        MobileServiceClient client;

        //Mobile Service sync table used to access data
        private IMobileServiceSyncTable<Question> questionTable;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.QuestionList);

            
            client = ((PanPanyaApp)Application).Client;
            adapter = new QuestionHeaderAdapter(this, Resource.Layout.QuestionListItem);
            var listViewToDo = FindViewById<ListView>(Resource.Id.listViewQuestion);
            listViewToDo.Adapter = adapter;

            questionTable = client.GetSyncTable<Question>();
            questionTable.PullAsync("allQuestions", questionTable.CreateQuery());
        }

        public void ViewQuestionPage ()
        {
            
        }
    }
}