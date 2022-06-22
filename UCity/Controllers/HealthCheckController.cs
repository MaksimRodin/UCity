using Microsoft.AspNetCore.Mvc;

namespace UCity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> IsAlive()
        {
            return Ok("The UCity service still working. You can sleep calmly ;-)");
        }
    }
}