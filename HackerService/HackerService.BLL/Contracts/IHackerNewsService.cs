using News = HackerService.BLL.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerService.BLL.Contracts
{
    public interface IHackerNewsService
    {
        /// <summary>
        /// Create a new item
        /// </summary>
        /// <param name="item/param>
        /// <returns></returns>
        //Task<News> CreateItemAsync(News item);

        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<News.News> GetNewsAsync(int id);

        /// <summary>
        /// Update item parameters
        /// </summary>
        /// <param name="item/param>
        /// <returns></returns>
        //Task<bool> UpdateItemAsync(News item);

        /// <summary>
        /// Delete item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Task<bool> DeleteitemAsync(int id);

        /// <summary>
        /// Get item list 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<News.News>> GetNewsListAsync(int apiRoute);
    }
}
