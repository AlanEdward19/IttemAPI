using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
