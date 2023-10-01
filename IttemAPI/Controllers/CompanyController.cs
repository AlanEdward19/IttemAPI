using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Company.CreateCompany;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CreateCompanyCommandHandler _createCommandHandler;

        public CompanyController(CreateCompanyCommandHandler createCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyCommand command) =>
            Ok(await _createCommandHandler.CreateCompany(command));
    }
}
