using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Polo.CreatePolo;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PoloController : ControllerBase
    {
        private readonly CreatePoloCommandHandler _createCommandHandler;

        public PoloController(CreatePoloCommandHandler createCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();

        [HttpPost]
        public async Task<IActionResult> Create(CreatePoloCommand command) =>
            Ok(await _createCommandHandler.CreatePolo(command));
    }
}
