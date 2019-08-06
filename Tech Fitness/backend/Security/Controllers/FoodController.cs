using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        // This will handle API data from vue front end
        // **** SAMPLE *******
        /// <summary>
        /// Gets a collection of values. The requestor must be authenticated.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var result = $"Welcome back {User.Identity.Name}";
            return Ok(result);
        }
    }
}