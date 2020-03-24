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
        //[InlineData("Story", NewsType.Story)]
        //[InlineData("Comment", NewsType.Comment)]
        //[InlineData("Poll", NewsType.Poll)]
        //public void CreateNews_Test(string itemTitle, NewsType itemType)
        //{
        //    //Arrange
        //    var fixture = new Fixture();
        //    var item = Fixtures.ItemFixture(itemTitle, itemType);
        //    var mapper = Mapper.GetAutoMapper();
        //    var newsRepoMoq = Moqs.NewsReposirotyMoq(mapper.Map<NewsEntity>(item));
        //    var newsSrc = new HackerNewsService(mapper, newsRepoMoq.Object);

        //    //Act
        //    var result = newsSrc.GetNewsListAsync(fixture.Create<Int32>()).Result;

        //    //Assert
        //    var actual = JsonConvert.SerializeObject(item);
        //    var expected = JsonConvert.SerializeObject(result);
        //    Assert.Equal(expected.Trim(), actual.Trim());
        //}

        [Fact]
        public void GetItem_Test()
        {
            //Arrange
            var fixture = new Fixture();

            var item = Fixtures.ItemFixture();
            var mapper = Mapper.GetAutoMapper();
            var newsRepoMoq = Moqs.NewsReposirotyMoq(mapper.Map<NewsEntity>(item));
            var newsSvc = new HackerNewsService(mapper, newsRepoMoq.Object);

            //Act
            var result = newsSvc.GetNewsAsync(fixture.Create<Int32>()).Result;

            //Assert
            var actual = JsonConvert.SerializeObject(item);
            var expected = JsonConvert.SerializeObject(result);
            Assert.Equal(expected.Trim(), actual.Trim());
        }
    }
}
