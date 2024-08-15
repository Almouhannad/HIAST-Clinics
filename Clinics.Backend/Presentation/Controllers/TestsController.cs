using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            object respone = new { Result = "Hello world!" };
            return Ok(respone);
        }
    }
}
