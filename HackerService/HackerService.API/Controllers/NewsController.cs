using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HackerService.API.Models;
using HackerService.API.Swagger;
using HackerService.BLL.Contracts;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace HackerService.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/news")]
    [ApiVersion("1.0")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHackerNewsService _hackerNewsService;

        /// <summary>
        /// News db api
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="hackerNewsService"></param>
        public NewsController(IMapper mapper, IHackerNewsService hackerNewsService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _hackerNewsService = hackerNewsService ?? throw new ArgumentNullException(nameof(hackerNewsService));
        }

        /// <summary>
        /// Create a News article
        /// </summary>
        /// <param name="article"></param>
        /// <returns>Returns created article</returns>           
        //[HttpPost("")]
        //[SwaggerResponseExample((int)HttpStatusCode.Created, typeof(NewsModelExample))]
        //[SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(News), Description = "Returns created article")]
        //[SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        //public async Task<IActionResult> CreateArticleAsync([FromBody] News article)
        //{
        //    if (ModelState != null && !ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var result = await _hackerNewsService.CreateArticleAsync(_mapper.Map<BLL.Models.News>(article));
        //    return Created($"{result.id}", _mapper.Map<News>(result));
        //}

        /// <summary>
        /// Get article by id
        /// </summary>
        /// <param name="id">News id</param>
        /// <returns>Returns finded article</returns>
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(News), Description = "Returns found article")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(NewsModelExample))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid article id")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetNewsAsync([FromRoute] Int32 id)
        {
            string.IsNullOrEmpty(id.ToString());

            if (id == 0)
            {
                return BadRequest();
            }

            var result = await _hackerNewsService.GetNewsAsync(id);
            if (result == null)
            {
                return NotFound(new { id });
            }

            return Ok(_mapper.Map<News>(result));
        }

        /// <summary>
        /// Update existing article
        /// </summary>
        /// <param name="id">News id</param>
        /// <param name="article">News parameters</param>
        /// <returns></returns>
        //[HttpPut("{id}")]
        //[SwaggerRequestExample(typeof(News), typeof(NewsModelExample))]
        //[SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        //[SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid article object")]
        //[SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        //public async Task<IActionResult> UpdateArticleAsync([FromRoute] Guid id, [FromBody] News article)
        //{
        //    if (id == Guid.Empty || !ModelState.IsValid) return BadRequest();
        //    article.Id = id;
        //    await _hackerNewsService.UpdateArticleAsync(_mapper.Map<BLL.Models.News>(article));
        //    return Ok();

        //}

        /// <summary>
        /// Delete article
        /// </summary>
        /// <param name="id">News id</param>
        /// <returns></returns>
        //[HttpDelete("{id}")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        //[SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid article id")]
        //[SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        //public async Task<IActionResult> DeleteArticleAsync([FromRoute] Guid id)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        await _hackerNewsService.DeleteArticleAsync(id);
        //        return Ok();
        //    }

        //    return BadRequest();
        //}

        /// <summary>
        /// Get article list
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        [HttpGet()]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<News>), Description = "Returns found articles array")]
       // [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid pageNumber or pageSize")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetNewsListAsync() //[FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50
        {
        //    if (pageNumber != 0 && pageSize != 0)
        //    {
                var result = await _hackerNewsService.GetNewsListAsync();
                return Ok(_mapper.Map<IEnumerable<News>>(result));
        //    }

        //    return BadRequest();
        }
    }
}
