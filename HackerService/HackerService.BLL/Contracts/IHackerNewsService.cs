using HackerService.BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerService.BLL.Contracts
{
    public interface IHackerNewsService
    {
        /// <summary>
        /// Create a new article
        /// </summary>
        /// <param name="article/param>
        /// <returns></returns>
        //Task<News> CreateArticleAsync(News article);

        /// <summary>
        /// Get article by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<News> GetNewsAsync(int id);

        /// <summary>
        /// Update article parameters
        /// </summary>
        /// <param name="article/param>
        /// <returns></returns>
        //Task<bool> UpdateArticleAsync(News article);

        /// <summary>
        /// Delete article by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Task<bool> DeleteArticleAsync(Guid id);

        /// <summary>
        /// Get article list 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<News>> GetNewsListAsync();
    }
}
