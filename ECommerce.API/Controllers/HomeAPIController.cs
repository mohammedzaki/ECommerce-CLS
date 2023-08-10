using ECommerce.Core.Data;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeAPIController : ControllerBase
    {

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {

            return Ok();
        }

        [HttpGet("GetData")]
        public async Task<ActionResult<User>> GetData()
        {
            var user = new User { };

            return user;
        }

    }
}
