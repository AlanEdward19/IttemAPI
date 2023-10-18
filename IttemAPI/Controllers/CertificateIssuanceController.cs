using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Queries.CertificateIssuance.GetCertificateIssuance;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "admin, worker")]
    [ApiController]
    public class CertificateIssuanceController : ControllerBase
    {
        private readonly GetCertificateIssuanceQueryHandler _queryHandler;

        public CertificateIssuanceController(GetCertificateIssuanceQueryHandler queryHandler)
        {
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string cpf) => Ok(await _queryHandler.Get(cpf));
    }
}
