using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        public InstructorController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();
    }
}
