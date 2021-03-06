using AutoMapper;
using HackerService.BLL.Contracts;
using HackerService.DAL.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using News = HackerService.BLL.Models.News;

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

        public async Task<News> GetNewsAsync(int id)
        {
            var item = await HackerNewsRepo.GetNewsAsync(id);
            return _mapper.Map<News>(item);
        }

        public async Task<IEnumerable<News>> GetNewsListAsync(int apiRoute)
        {
            var item = await HackerNewsRepo.GetNewsListAsync(apiRoute);
            return _mapper.Map<IEnumerable<News>>(item);
        }

      
    }
}
