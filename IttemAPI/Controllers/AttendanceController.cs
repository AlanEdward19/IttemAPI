using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        public AttendanceController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();
    }
}
