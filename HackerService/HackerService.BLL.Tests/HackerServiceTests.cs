using AutoFixture;
using HackerService.BLL.Tests.Helpers;
using Xunit;
using HackerService.DAL.Models;
using System;
using Newtonsoft.Json;
using HackerService.BLL.Models;

namespace HackerService.BLL.Tests
{
    public class HackerNewsServiceTests
    {
        //[Theory]
        //[InlineData("Story", NewsType.story)]
        //[InlineData("Comment", NewsType.comment)]
        //[InlineData("Poll", NewsType.poll)]
        //public void CreateNews_Test(string articleTitle, NewsType articleType)
        //{
        //    //Arrange
        //    var fixture = new Fixture();
        //    var article = Fixtures.ArticleFixture(articleTitle, articleType);
        //    var mapper = Mapper.GetAutoMapper();
        //    var newsRepoMoq = Moqs.NewsReposirotyMoq(mapper.Map<NewsEntity>(article));
        //    var newsSrc = new HackerNewsService(mapper, newsRepoMoq.Object);

        //    //Act
        //    var news = newsSrc.CreateArticleAsync(article);

        //    //Assert
        //    var actual = JsonConvert.SerializeObject(article);
        //    var expected = JsonConvert.SerializeObject(news);
        //    Assert.Equal(expected.Trim(), actual.Trim());
        //}

        [Fact]
        public void GetArticle_Test()
        {
            //Arrange
            var fixture = new Fixture();

            var article = Fixtures.ArticleFixture();
            var mapper = Mapper.GetAutoMapper();
            var newsRepoMoq = Moqs.NewsReposirotyMoq(mapper.Map<NewsEntity>(article));
            var newsSvc = new HackerNewsService(mapper, newsRepoMoq.Object);

            //Act
            var result = newsSvc.GetNewsAsync(fixture.Create<Int32>()).Result;

            //Assert
            var actual = JsonConvert.SerializeObject(article);
            var expected = JsonConvert.SerializeObject(result);
            Assert.Equal(expected.Trim(), actual.Trim());
        }
    }
}
