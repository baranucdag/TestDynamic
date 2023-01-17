using DynamicAPI.Persitence.Models.Dynamic;
using DynamicAPI.Persitence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DynamicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UsersController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        UserRepository userRepository = new UserRepository();

        [HttpPost("GetList")]
        public IActionResult GetListByDynamic([FromBody] Dynamic dynamic)
        {
            //get header from httpContextAccessor
            //var pagingHeader = _httpContextAccessor.HttpContext.Request.Headers["X-Paging-Header"];
            // var x = JsonConvert.DeserializeObject<Dynamic>(pagingHeader.FirstOrDefault());

            var result = userRepository.GetListByDynamic(dynamic, index: dynamic.PageRequest.Page, size: dynamic.PageRequest.PageSize);
            return Ok(result);
        }

    }
}

/*
 
 {
"sort": [
    {
      "field": "id",
      "dir": "desc"
    }
  ],
  "filter": {
    "field": "firstName",
    "operator": "contains",
    "value": "user",
    "logic": "and",
    "filters": [
    {
  "field": "lastName",
    "operator": "contains",
    "value": "user",
    "logic": "or"
    },
    {
  "field": "passwordHash",
    "operator": "contains",
    "value": "abcde"
    }
   ]
  },
  "pageRequest": {
    "page": 0,
    "pageSize": 10
  }
}
 * */





/*
{"filter": {"field": "firstName","operator": "contains","value": "user2","logic": "and","filters": []},"pageRequest": {"page": 0,"pageSize": 0}} 


 * */
