using HackerService.API.Models;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace HackerService.API.Swagger
{
    public class NewsModelExample : IExamplesProvider<News>
    {
        public News GetExamples()
        {
            var now = DateTime.UtcNow;
            return new News
            {
                id = 22638207,
                title = "Ask HN: The Arc Effect",
                type = NewsType.Story,
                time = now,
              
            };
        }
    }
}
