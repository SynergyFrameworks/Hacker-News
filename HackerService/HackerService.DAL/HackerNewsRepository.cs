using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FireSharp;
using HackerService.DAL.Contract;
using HackerService.DAL.Models;
using FireSharp.Config;
using FireSharp.Extensions;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Newtonsoft.Json;

namespace HackerService.DAL
{
    public class HackerNewsRepository : IHackerNewsRepository, IHealthCheck

    {
        private readonly IFirebaseConfig _config = new FirebaseConfig()
        {
            // AuthSecret = "",
            BasePath = "https://hacker-news.firebaseio.com/v0/",
            // Host = ""
        };


        private IFirebaseClient _client;

        private readonly IOptionsMonitor<HackerNewsRepositoryOption> _options;

        public HackerNewsRepository(IOptionsMonitor<HackerNewsRepositoryOption> options)
        {
            _options = options;
            _client = new FirebaseClient(_config);

        }


        public async Task<NewsEntity> GetNewsAsync(int id)
        {
            FirebaseResponse response = await _client.GetAsync($"item/{id}.json?print=pretty");

            return response.ResultAs<NewsEntity>();

        }
      

        public static T Deserialize<T>(string json)
        {
            Newtonsoft.Json.JsonSerializer s = new JsonSerializer();
            return s.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }


        private string ApiPathBuilder(int apiRoute)
        {

            string route = "showstories.json?print=pretty";

            switch (apiRoute)
            {
                case 1:
                    route = "topstories.json?print=pretty"; 
                    break;
                case 2:
                    route = "showstories.json?print=pretty";
                    break;
                case 3:
                    route = "jobstories.json?print=pretty";
                    break;
                default:
                    route = "showstories.json?print=pretty";
                    break;
            }

            return route;




        }
        public async Task<IEnumerable<NewsEntity>> GetNewsListAsync(int apiRoute)
        {

            
            FirebaseResponse response = await _client.GetAsync(ApiPathBuilder(apiRoute));
            List<NewsEntity> news = new List<NewsEntity>();

            var hackernewslist = response.Body.ToJson();
            char[] delimiterChars = { ',' };

            string[] ids = hackernewslist.Split(delimiterChars);
            // string idstemp = ids.First().Replace("\"[", string.Empty);
            // string idstemp2 = ids.Last().Replace("]\"", string.Empty);

            var tasks = ids.Select(async item =>
            {
                var temp = item.Replace("\"[", string.Empty);
                var temp2 = temp.Replace("]\"", string.Empty);

                // some pre stuff
                FirebaseResponse itemresponse = await _client.GetAsync($"item/{temp2}.json?print=pretty");
                var entity = itemresponse.ResultAs<NewsEntity>();

                news.Add(entity);
                // some post stuff
            });
            await Task.WhenAll(tasks);
            

            return news; 
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
