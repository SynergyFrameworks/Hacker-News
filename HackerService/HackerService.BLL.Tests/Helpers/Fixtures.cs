using AutoFixture;
using HackerService.BLL.Models;

namespace HackerService.BLL.Tests.Helpers
{
    public static class Fixtures
    {
        public static News ArticleFixture(string itemTitle = null, NewsType newsType = 0)
        {
            var fixture = new Fixture();

            var news = fixture.Build<News>();

            if (!string.IsNullOrEmpty(itemTitle))
            {
                news.With(s => s.title, itemTitle);
            }

            if (newsType > 0)
            {
         //       news.With(s => s.type, (DAL.Models.NewsType) newsType);
            }

            return news.Create();
        }
    }
}
