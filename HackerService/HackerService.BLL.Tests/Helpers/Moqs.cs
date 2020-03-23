using AutoFixture;
using Moq;
using HackerService.BLL.Contracts;
using HackerService.BLL.Models;
using HackerService.DAL.Contract;
using HackerService.DAL.Models;
using News = HackerService.BLL.Models.News;


namespace HackerService.BLL.Tests.Helpers
{
    public static class Moqs
    {
        public static Mock<IHackerNewsService> NewsServiceMoq()
        {
            var fixture = new Fixture();

            var moq = new Mock<IHackerNewsService>(MockBehavior.Strict);
            //moq.Setup(s => s.CreateArticleAsync(It.IsAny<News>()))
            //  .ReturnsAsync(fixture.Build<News>().Create());
            //moq.Setup(s => s.UpdateArticleAsync(It.IsAny<News>()))
            //  .ReturnsAsync(true);
            //moq.Setup(s => s.DeleteArticleAsync(It.IsAny<Guid>()))
            //.ReturnsAsync(true);
            moq.Setup(s => s.GetNewsAsync(It.IsAny<int>()))
                .ReturnsAsync(fixture.Build<News>().Create());
            moq.Setup(s => s.GetNewsListAsync())
             .ReturnsAsync(fixture.Build<News>().CreateMany(20));

            return moq;
        }

        public static Mock<IHackerNewsRepository> NewsReposirotyMoq(NewsEntity newsEntity)
        {
            var fixture = new Fixture();

            var moq = new Mock<IHackerNewsRepository>(MockBehavior.Strict);

            //moq.Setup(s => s.CreateArticleAsync(It.IsAny<NewsEntity>()))
            //  .ReturnsAsync(newsEntity);
            //moq.Setup(s => s.UpdateArticleAsync(It.IsAny<NewsEntity>()))
            //  .ReturnsAsync(true);
            //moq.Setup(s => s.DeleteArticleAsync(It.IsAny<Guid>()))
            //.ReturnsAsync(true);

            moq.Setup(s => s.GetNewsAsync(It.IsAny<int>()))
                .ReturnsAsync(newsEntity);
            moq.Setup(s => s.GetNewsListAsync())
             .ReturnsAsync(fixture.Build<NewsEntity>().CreateMany(20));

            return moq;
        }
    }
}
