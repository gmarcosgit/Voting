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
using RestSharp;

namespace Voting.Services
{
    public interface IBaseService
    {
        string BaseUrl { get; set; }
        Task<T> ExecuteAsync<T>(RestRequest baseUrl) where T : new();
    }
}