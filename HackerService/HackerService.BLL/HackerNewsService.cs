using AutoMapper;
using HackerService.BLL.Contracts;
using HackerService.BLL.Models;
using HackerService.DAL.Contract;
using HackerService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerService.BLL
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly IMapper _mapper;

        public IHackerNewsRepository HackerNewsRepo { get; }

        public HackerNewsService(IMapper mapper, IHackerNewsRepository hackerNewsRepo)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            HackerNewsRepo = hackerNewsRepo ?? throw new ArgumentNullException(nameof(hackerNewsRepo));
        }

        //public async Task<News> CreateArticleAsync(News article)
        //{
        //  var newsarticle = await HackerNewsRepo.CreateArticleAsync(_mapper.Map<NewsEntity>(article));
        //    return _mapper.Map<News>(newsarticle);
        //} 

        //public async Task<bool> UpdateArticleAsync(News article)
        //{
        //    var result = await HackerNewsRepo.UpdateArticleAsync(_mapper.Map<NewsEntity>(article));
        //    return result;
        //}

        //public async Task<bool> DeleteArticleAsync(Guid id)
        //{
        //    var result = await HackerNewsRepo.DeleteArticleAsync(id);
        //    return result;
        //}

        public async Task<News> GetNewsAsync(int id)
        {
            var article = await HackerNewsRepo.GetNewsAsync(id);
            return _mapper.Map<News>(article);
        }

        public async Task<IEnumerable<News>> GetNewsListAsync()
        {
            var articles = await HackerNewsRepo.GetNewsListAsync();
            return _mapper.Map<IEnumerable<News>>(articles);
        }

      
    }
}
