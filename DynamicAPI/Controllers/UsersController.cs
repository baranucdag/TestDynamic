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

        [HttpGet("GetList")]
        public IActionResult GetListByDynamic()
        {
            //get header from httpContextAccessor
            var pagingHeader = _httpContextAccessor.HttpContext.Request.Headers["X-Paging-Header"];
             var x = JsonConvert.DeserializeObject<Dynamic>(pagingHeader.FirstOrDefault());

            var result = userRepository.GetListByDynamic(x, index: x.PageRequest.Page, size: x.PageRequest.PageSize);
            return Ok(result);
        }

    }
}

/*
 
 {
"sort": [
    {
      "field": "firstName",
      "dir": "asc"
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
    "operator": "eq",
    "value": "user"
    },
    {
  "field": "passwordHash",
    "operator": "contains",
    "value": "a"
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
