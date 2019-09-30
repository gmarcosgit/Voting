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

namespace Voting.Services
{
    public class VoteService : BaseService
    {
        public VoteService()
        {
            BaseUrl = string.Format("http://192.168.100.205:80/api");
            //BaseUrl = string.Format("http://localhost:58700/api");
        }
    }
}