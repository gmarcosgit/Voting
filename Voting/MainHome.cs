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
using BusinessObjects;
using Newtonsoft.Json;

namespace Voting
{
    [Activity(Label = "MainHome")]
    public class MainHome : Activity
    {
        Button btnVote;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.mainhome);
            // Create your application here

            btnVote = FindViewById<Button>(Resource.Id.btnVote);
            btnVote.Click += BtnVote_Click;   
        }

        private void BtnVote_Click(object sender, EventArgs e)
        {
            var receivedItems = JsonConvert.DeserializeObject<Students>(Intent.GetStringExtra("student"));

            var intent = new Intent(this, typeof(VoteActivity));
            intent.PutExtra("student", JsonConvert.SerializeObject(receivedItems));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slideright, Resource.Animation.slideright);
        }
    }
}