using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CertificateIssuanceController : ControllerBase
    {
        public CertificateIssuanceController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();
    }
}
