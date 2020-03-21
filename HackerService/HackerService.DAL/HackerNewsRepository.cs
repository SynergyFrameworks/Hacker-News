using Dapper;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FireSharp;
using HackerService.DAL.Contract;
using HackerService.DAL.Models;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using RestSharp;

namespace HackerService.DAL
{
    public class HackerNewsRepository : IHackerNewsRepository, IHealthCheck

    {
        private readonly IFirebaseConfig _config = new FirebaseConfig()
        {
            AuthSecret = "",
            BasePath = "https://hacker-news.firebaseio.com/v0/",
            /// TODO BasePath = "https://hacker-news.firebaseio.com/v0/showstories.json",
            ///
            //loadItem(){
            //this.http.get(`https://hacker- 
            //news.firebaseio.com/v0/item/${this.id}.json?print=pretty`).subscribe(data => {
            //    this.items.push(data as any[]);
            //  })
            //}  
            Host = ""
        };
       // //https://hacker-news.firebaseio.com/v0/item/2921983.json?print=pretty
        //beststories.json?print=pretty&orderBy="$key"&limitToFirst=5

        private IFirebaseClient _client;

        private readonly IOptionsMonitor<HackerNewsRepositoryOption> _options;

        public HackerNewsRepository(IOptionsMonitor<HackerNewsRepositoryOption> options)
        {
            _options = options;
           _client = new FirebaseClient(_config);

        }

        //public async Task<NewsEntity> CreateArticleAsync(NewsEntity news)
        //{

        //    _client = new FirebaseClient(_config);
        //    if (news.id == Guid.Empty.ToString())
        //    {
        //        news.id = Guid.NewGuid().ToString();
        //    }
        //    var now = DateTime.UtcNow;
        //    news.time = now;


        //    _client = new FirebaseClient(_config); 
        //    await _client.SetAsync("todos/set", news);
        //    return news;

        //}

        public async Task<NewsEntity> GetNewsAsync(int id)
        {
            FirebaseResponse response = await _client.GetAsync($"item/{id}.json?print=pretty");
            return response.ResultAs<NewsEntity>();

            //var client = new RestClient("https://hacker-news.firebaseio.com/v0/item/%7Bitem-id%7D.json?print=pretty");
            //var request = new RestRequest(Method.GET);
            //request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);



        }

        //public async Task<bool> UpdateArticleAsync(NewsEntity news)
        //{
        //    news.time = DateTime.UtcNow;
        //    var response = await _client.UpdateAsync("todos/set", news);
        //    var article = response.ResultAs<NewsEntity>(); //The response will contain the data written

        //    return article != null;
        //}

        //public async Task<bool> DeleteArticleAsync(Guid id)
        //{
        //    var response = await _client.DeleteAsync("todos"); //Deletes collection
        //  return response.StatusCode == HttpStatusCode.OK;
        //}

        public async Task<IEnumerable<NewsEntity>> GetNewsListAsync()
        {
            FirebaseResponse response = await _client.GetAsync("topstories?print=pretty");
            return response.ResultAs<IEnumerable<NewsEntity>>();

        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
      
                try
                { 
                  //  EventStreamResponse response = await _client.OnAsync("chat", (sender, args);
                  return await Task.FromResult(HealthCheckResult.Healthy());
                }
                catch
                {
                    return await Task.FromResult(HealthCheckResult.Unhealthy());
                }

        }
    }
}
