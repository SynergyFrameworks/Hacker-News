using HackerService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerService.DAL.Contract
{
    public interface IHackerNewsRepository
    {

        Task<NewsEntity> GetNewsAsync(int id);
        
        Task<IEnumerable<NewsEntity>> GetNewsListAsync(int apiRoute);
    }
}
