using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using BusinessObjects;
using Java.IO;
using Newtonsoft.Json;
using RestSharp;
using Voting.Services;

namespace Voting
{
    [Activity(Label = "LogInActivity")]
    public class LogInActivity : Activity
    {
        EditText userName, passWord;
        Button Login;
        Students student = new Students();
        ProgressBar load;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.logIn);
            userName = FindViewById<EditText>(Resource.Id.editTextUserName);
            passWord = FindViewById<EditText>(Resource.Id.editTextPassword);
            load = FindViewById<ProgressBar>(Resource.Id.progressbar);

            Login = FindViewById<Button>(Resource.Id.btnLogin);
            Login.Click += Login_Click;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            var a = student.FullName;
            if (string.IsNullOrWhiteSpace(userName.Text) | string.IsNullOrWhiteSpace(passWord.Text))
            {
                Toast.MakeText(this, "Username or Password is required.", ToastLength.Long).Show();
            }
            else
                GetStudents();

        }

        public async Task GetStudents()
        {
            var request = new RestRequest("voting/GetLoginStudents", Method.GET);
            request.AddQueryParameter("StudentNumber", userName.Text);
            request.AddQueryParameter("Password", passWord.Text);
            var voteService = new VoteService();
            var result = await voteService.ExecuteAsync<Students>(request);
            student = result;
            
            if (student.StudentNumber != 0)
            {
                var text = "Successfully Login.";
                SpannableStringBuilder biggerText = new SpannableStringBuilder(text);
                biggerText.SetSpan(new RelativeSizeSpan(1.35f), 0, text.Length, 0);
                Toast.MakeText(this, biggerText, ToastLength.Long).Show();

                load.Visibility = ViewStates.Visible;

                Intent intent = new Intent(this, typeof(MainHome));
                intent.PutExtra("student", JsonConvert.SerializeObject(student));
                StartActivity(intent);
                Finish();
                
            }
            //else if(student.DateTimeVoted != null)
            //{
            //    var text = "Already Voted.";
            //    SpannableStringBuilder biggerText = new SpannableStringBuilder(text);
            //    biggerText.SetSpan(new RelativeSizeSpan(1.35f), 0, text.Length, 0);
            //    Toast.MakeText(this, biggerText, ToastLength.Long).Show();
            //}
            else
            {
                var text = "Invalid Username or Password.";
                SpannableStringBuilder biggerText = new SpannableStringBuilder(text);
                biggerText.SetSpan(new RelativeSizeSpan(1.35f), 0, text.Length, 0);
                Toast.MakeText(this, biggerText, ToastLength.Long).Show();
            }
        }


    }
}