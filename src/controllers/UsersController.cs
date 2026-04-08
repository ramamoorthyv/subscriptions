using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Subscription.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
            [HttpGet]
            public IActionResult Get()
            {
                return Ok("Hello from UserController");
            }
    }
}
