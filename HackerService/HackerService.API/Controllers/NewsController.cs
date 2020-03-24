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
    // [Authorize]
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
        /// Get item list
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="apiRoute">API Route</param>
        /// <returns></returns>
        [HttpGet()]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<News>), Description = "Returns found articles array")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid pageNumber or pageSize")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetNewsListAsync([FromQuery] int apiRoute = 1) //[FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50
        {
            if (apiRoute != 0 && apiRoute != 0)
            {
                var result = await _hackerNewsService.GetNewsListAsync(apiRoute);
            return Ok(result);
            }

            return BadRequest();
        }

        /// <summary>
        /// Get item by id
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

            return Ok(result);
        }

       
    }
}
