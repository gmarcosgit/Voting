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
using RestSharp;
using Voting.Services;

namespace Voting
{
    [Activity(Label = "ReviewVotes")]
    public class ReviewVotes : Activity
    {
        TextView presidentresult, vicepresidentresult, secretaryresult, treasureresult, auditorresult, businessresult, publicresult1;
        Button btnEdit, btnSubmit;

        List<AuditTrailVote> pickedVote = new List<AuditTrailVote>();
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ReviewVote);

            presidentresult = FindViewById<TextView>(Resource.Id.viewpresident);
            vicepresidentresult = FindViewById<TextView>(Resource.Id.viewvicepresident);
            secretaryresult = FindViewById<TextView>(Resource.Id.viewsecretary);
            treasureresult = FindViewById<TextView>(Resource.Id.viewtreasurer);
            auditorresult = FindViewById<TextView>(Resource.Id.viewAuditor);
            businessresult = FindViewById<TextView>(Resource.Id.viewBusMngr);
            publicresult1 = FindViewById<TextView>(Resource.Id.viewPubInfoOfficer);

            btnEdit = FindViewById<Button>(Resource.Id.btnedit);
            btnSubmit = FindViewById<Button>(Resource.Id.btnsubmit);

            btnEdit.Click += BtnEdit_Click;
            btnSubmit.Click += BtnSubmit_Click;

            var receivedItems = JsonConvert.DeserializeObject<List<VoteData>>(Intent.GetStringExtra("voteData"));
            var candidates = JsonConvert.DeserializeObject<List<Candidates>>(Intent.GetStringExtra("candidates"));

            var _candidate = candidates.Where(candidate => receivedItems.Any(voted => voted.CandidateStudentNumber == candidate.StudentNumber)).ToList();
            var data = _candidate.Select(item => item.FullName);
          
            var queryLondonCustomers = from item in receivedItems
                                        join candidate in candidates on item.CandidateStudentNumber equals candidate.StudentNumber
                                        select new { candidate.FullName, candidate.Position };

            foreach (var item in queryLondonCustomers)
            {
                if(item.Position == "President")
                    presidentresult.Text = item.FullName;
                if(item.Position == "Vice-President")
                    vicepresidentresult.Text = item.FullName;
                if (item.Position == "Secretary")
                    secretaryresult.Text = item.FullName;
                if (item.Position == "Treasurer")
                    treasureresult.Text = item.FullName;
                if (item.Position == "Auditor")
                    auditorresult.Text = item.FullName;
                if (item.Position == "Business Manager")
                    businessresult.Text = item.FullName;
                if (item.Position == "Public Information Officer")
                    publicresult1.Text = item.FullName;
            }
            var studentnumber = receivedItems.First(x => x.StudentNumber != 0);
            pickedVote.Add(new AuditTrailVote
            {
                StudentNumber = studentnumber.StudentNumber,
                President = presidentresult.Text,
                VicePresident = vicepresidentresult.Text,
                Secretary = secretaryresult.Text,
                Treasurer = treasureresult.Text,
                Auditor = auditorresult.Text,
                BusinessManager = businessresult.Text,
                PublicInformationOfficer = publicresult1.Text,
            });

            var button = new ImageButton(this)
            {
                LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent),
                
                Id = 1 + 1,
            };

        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            //var pickedVote = new List<AuditTrailVote>();
            //pickedVote.Add(new AuditTrailVote
            //    {
            //        StudentNumber   =,
            //        President       =,
            //        VicePresident   =,
            //        Secretary       =,
            //        Treasurer       =,
            //        Auditor         =,
            //        BusinessManager =,
            //        PublicInformationOfficer =,
            //});

            InsertVoteData(pickedVote);
            StartActivity(typeof(Finish));
            Finish();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Finish();
        }

        public void GetAnswer(ViewGroup parent)
        {
            List<VoteData> votes = new List<VoteData>();
            for (int i = 0; i < parent.ChildCount; i++)
            {
                View child = parent.GetChildAt(i);
                if (child is RadioGroup)
                {
                    var rdgrp = (RadioGroup)child;

                    if (rdgrp.CheckedRadioButtonId > -1)
                    {
                        votes.Add(new VoteData
                        {
                            StudentNumber = 201901001,
                            FirstName = "Jason",
                            MI = "T.",
                            LastName = "Dee",
                            GradeLevel = 7,
                            Section = "St Anthony",
                            CandidateStudentNumber = 201901001,
                            Position = "President",
                        });
                    }
                }
            }
           // InsertVoteData(votes);
        }
        private bool InsertVoteData(List<AuditTrailVote> votedata)
        {
            var request = new RestRequest("voting/insertAuditVote")
            {
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(votedata);

            var questService = new VoteService();
            var result = questService.ExecuteAsync<bool>(request);

            return result.Result;
        }
    }
}