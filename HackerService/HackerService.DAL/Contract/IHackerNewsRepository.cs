using HackerService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerService.DAL.Contract
{
    public interface IHackerNewsRepository
    {
        //Task<NewsEntity> CreateArticleAsync(NewsEntity news);
        //Task<bool> UpdateArticleAsync(NewsEntity news);
        //Task<bool> DeleteArticleAsync(Guid id);
        Task<NewsEntity> GetNewsAsync(int id);
        
        Task<IEnumerable<NewsEntity>> GetNewsListAsync();
    }
}
