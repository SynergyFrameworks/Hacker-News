using System;
using Dapper;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace HackerService.DAL
{
    public class HackerNewsRepository : IHackerNewsRepository, IHealthCheck

    {
        private readonly IFirebaseConfig _config = new FirebaseConfig()
        {
           // AuthSecret = "",
            BasePath = "https://hacker-news.firebaseio.com/v0/",
            //Host = ""
        };
        
        public IFirebaseClient GetFirebaseClient(string node)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
         //       AuthSecret = _firebaseSecret,
                BasePath = node
            };
            IFirebaseClient client = new FirebaseClient(config);
            return client;
        }


        private IFirebaseClient _client;

        private readonly IOptionsMonitor<HackerNewsRepositoryOption> _options;

        public HackerNewsRepository(IOptionsMonitor<HackerNewsRepositoryOption> options)
        {
            _options = options;
           _client = new FirebaseClient(_config);

        }



        //public IEnumerable<NewsEntity> HackerNewsFormatter(FirebaseResponse response)
        //{

        //    response.Body
        //    //return;
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
        //private IEnumerable<T> ConcatSingle<T>(IEnumerable<T> source, string item)
        //{
        //    return source.Concat(new[] { item });
        //}

        public static T Deserialize<T>(string json)
        {
            Newtonsoft.Json.JsonSerializer s = new JsonSerializer();
            return s.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }


        public async Task<IEnumerable<NewsEntity>> GetNewsListAsync()
        {
            FirebaseResponse response = await _client.GetAsync("showstories.json?print=pretty");

            IEnumerable<NewsEntity> news = new List<NewsEntity>();
          


            var hackernewslist  = response.Body.ToJson();
            //var jcso = JsonConvert.SerializeObject(response).ToString();
            char[] delimiterChars = {','};

            string[] ids = hackernewslist.Split(delimiterChars);
           // string idstemp = ids.First().Replace("\"[", string.Empty);
           // string idstemp2 = ids.Last().Replace("]\"", string.Empty);



            //var count = ids.Length;
            foreach (string el in ids)
            {
                //if (ids[0] == ids.First()) { }
                //if (ids[count] == ids.Last()) { }
                var temp = el.Replace("\"[", string.Empty);
                var temp2 = temp.Replace("]\"", string.Empty);

                FirebaseResponse itemresponse = await _client.GetAsync($"item/{temp2}.json?print=pretty");
                var test = JsonConvert.SerializeObject(itemresponse.Body);

                var Model = JsonConvert.DeserializeObject<NewsEntity>(test);
                //JObject o = JObject.Parse(itemresponse.Body);
                //ConcatSingle<NewsEntity>(news, JsonConvert.SerializeObject(itemresponse).ToString());
                //news =  Deserialize<NewsEntity>(itemresponse.Body);
                IEnumerable<NewsEntity> newsItem = new List<NewsEntity>();


                news.Concat(newsItem);
                
                
                //foreach (var newsEntity in news.Append<NewsEntity>( newsItems)) 




                // TODO - [itemresponse] take this data and insert into enumeration of type NewsEntity



            }

            //using (var s = response.Body.Length())
            //{
            //    using (var sr = new StreamReader(s))
            //    {
            //        var contributorsAsJson = sr.ReadToEnd();
            //        var contributors = JsonConvert.DeserializeObject<List<Contributor>>(contributorsAsJson);
            //        //contributors.ForEach(Console.WriteLine);
            //    }

            //}



            return news; //response.ResultAs<IEnumerable<NewsEntity>>();

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
