using Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Class.CreateClass;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly CreateClassCommandHandler _createCommandHandler;

        public ClassController(CreateClassCommandHandler createCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();

        [HttpPost]
        public async Task<IActionResult> Create(CreateClassCommand command) =>
            Ok(await _createCommandHandler.CreateClass(command));
    }
}
