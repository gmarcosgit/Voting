using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BusinessObjects;
using Newtonsoft.Json;
using RestSharp;
using Voting.Services;

namespace Voting
{
    [Activity(Label = "VoteActivity")]
    public class VoteActivity : Activity
    {
        RadioGroup _president, _vicepresident, _secretary, _treasurer, _auditor, _businessmgr, _publicinfOfficer;
        LinearLayout layout;
        List<Candidates> candidate;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.voteactivity);
            layout = FindViewById<LinearLayout>(Resource.Id.votelayout);
            //var candidates = GetAllCandidates();

            GetAllCandidates();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            GetAnswer(layout);
        }

        public async Task GetAllCandidates()
        {
            var request = new RestRequest("voting/getallcandidates", Method.GET);
            var voteService = new VoteService();
            var result = await voteService.ExecuteAsync<List<Candidates>>(request);
            candidate = result;
            var postion = result.Select(item => item.Position).Distinct().ToList();
            foreach (var pos in postion)
            {
                var button = new Button(this)
                {
                    Text = pos,
                    LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent),
                    Id = 1 + 1
                };
                layout.AddView(button);
                var rdg = new RadioGroup(this)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent),
                    Id = 1 + 1
                };

                foreach (var candidate in result)
                {
                    if(pos == candidate.Position)
                    {
                        var radioButton = new RadioButton(this);
                        radioButton.Id = candidate.StudentNumber;
                        radioButton.Text = candidate.FullName;
                        rdg.AddView(radioButton);
                    }
                }
                layout.AddView(rdg);
            }
            var btnFinish = new Button(this);
            btnFinish.Text = "Finish";
            btnFinish.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            btnFinish.Click += BtnFinish_Click;
            layout.AddView(btnFinish);
        }

        public void GetAnswer(ViewGroup parent)
        {
            string position;
            var receivedItems = JsonConvert.DeserializeObject<Students>(Intent.GetStringExtra("student"));
            List<VoteData> votes = new List<VoteData>();
            List<Candidates> candidates = new List<Candidates>();
            for (int i = 0; i < parent.ChildCount; i++)
            {
                View child = parent.GetChildAt(i);
                if(child is RadioGroup)
                {
                    var previousChildren = layout.GetChildAt(i - 1);

                    var btn = (Button)previousChildren;
                    position = btn.Text;
                    
                    RadioGroup rdgrp = (RadioGroup)child;

                    if (rdgrp.CheckedRadioButtonId > -1)
                    {
                        votes.Add(new VoteData
                        {
                            StudentNumber = receivedItems.StudentNumber,
                            FirstName = receivedItems.FirstName,
                            MI = receivedItems.MI,
                            LastName = receivedItems.LastName,
                            GradeLevel = receivedItems.GradeLevel,
                            Section = receivedItems.Section,
                            CandidateStudentNumber = rdgrp.CheckedRadioButtonId,
                            Position = position,
                        });

                    }
                }
            }
            var intent = new Intent(this, typeof(ReviewVotes));
            intent.PutExtra("voteData", JsonConvert.SerializeObject(votes));
            intent.PutExtra("candidates", JsonConvert.SerializeObject(candidate));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slideright, Resource.Animation.slideright);
        }
    }
}



//var client = new RestClient("http://192.168.100.205:80/api");
//var request = new RestRequest("voting/getallcandidates", Method.GET);
// return result;
//var content = client.Execute(request).Content;   
//Toast.MakeText(this, "Please Vote Wisely!", ToastLength.Long).Show();