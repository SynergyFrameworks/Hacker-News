using AutoFixture;
using HackerService.BLL.Models;

namespace HackerService.BLL.Tests.Helpers
{
    public static class Fixtures
    {
        public static News ArticleFixture(string articleTitle = null, NewsType newsType = 0)
        {
            var fixture = new Fixture();

            var article = fixture.Build<News>();

            if (!string.IsNullOrEmpty(articleTitle))
            {
                article.With(s => s.title, articleTitle);
            }

            if (newsType > 0)
            {
                article.With(s => s.type, newsType);
            }

            return article.Create();
        }
    }
}
