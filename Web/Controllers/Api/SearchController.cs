using Application.Tags.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Web;
using Web.Models;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public SearchController(IMediator mediatR)
        {           
            _mediatR = mediatR;
        }


        /// <summary>
        /// Query the tags available in the system
        /// </summary>
        /// <param name="searchTag"></param>
        /// <returns>Tags for the component</returns>
        [HttpPost]
        public async Task<IActionResult> SearchTags([FromBody]SearchTag searchTag)
        {
            var searchQuery = Uri.UnescapeDataString(searchTag.Query);

            if (string.IsNullOrEmpty(searchQuery)){
                return BadRequest();
            }

            var result = await _mediatR.Send(new GetTagsByNameQuery() { Query = searchQuery });

            if(result is null)
            {
                return NotFound();
            }


            return new JsonResult(result);
            
        }        
       
    }
}
