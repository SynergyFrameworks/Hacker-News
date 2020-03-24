using AutoFixture;
using HackerService.BLL.Models;
using HackerService.DAL.Models;

namespace HackerService.BLL.Tests.Helpers
{
    public static class Fixtures
    {
        public static News ItemFixture(string itemTitle = null, NewsType newsType = 0)
        {
            var fixture = new Fixture();

            var news = fixture.Build<News>();

            if (!string.IsNullOrEmpty(itemTitle))
            {
                news.With(s => s.title, itemTitle);
            }

            if (newsType > 0)
            {
         //       news.With(s => s.type, (NewsType)newsType);
            }

            return news.Create();
        }
    }
}
