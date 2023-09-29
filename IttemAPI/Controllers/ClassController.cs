using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        public ClassController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();
    }
}
