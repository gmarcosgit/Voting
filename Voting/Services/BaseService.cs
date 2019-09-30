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
    public class BaseService : IBaseService
    {
        public string BaseUrl { get; set; }

        public Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(BaseUrl);
            var taskCompletionSource = new TaskCompletionSource<T>();

            client.ExecuteAsync<T>(request, (response) => taskCompletionSource.SetResult(response.Data));
            return taskCompletionSource.Task;
        }
    }
}