using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers.v2
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion(2)]
    public class HelloWorld : ControllerBase
    {
        [HttpGet("hello-world")]
        public IActionResult Hello()
        {
            return Ok("Hello");
        }
    }
}
