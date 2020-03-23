using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerService.DAL.Helpers
{
    public static class HackerNewsConstants
    {
        public const string Url = "https://hacker-news.firebaseio.com/v0";

        public const string TopStories = "topstories.json";
        public const string MaxItem = "maxitem.json";

        public const string Item = "item/{0}.json";
        public const string User = "user/{0}.json";
        public const string Changes = "updates.json";

    }
}
