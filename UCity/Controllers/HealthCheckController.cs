using Microsoft.AspNetCore.Mvc;

namespace UCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> IsAlive()
        {
            return Ok("The UCity service still working. You can sleep calmly ;-)");
        }
    }
}