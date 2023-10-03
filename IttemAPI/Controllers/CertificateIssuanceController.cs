using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "admin, worker")]
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
