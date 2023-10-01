using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Company.CreateCompany;
using Services.Queries.Company.GetCompany;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CreateCompanyCommandHandler _createCommandHandler;
        private readonly GetCompanyQueryHandler _queryHandler;

        public CompanyController(CreateCompanyCommandHandler createCommandHandler, GetCompanyQueryHandler queryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? cnpj) => Ok(await _queryHandler.Get(cnpj));

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyCommand command) =>
            Ok(await _createCommandHandler.CreateCompany(command));
    }
}
