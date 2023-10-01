using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Function.CreateFunction;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        private readonly CreateFunctionCommandHandler _createCommandHandler;

        public FunctionController(CreateFunctionCommandHandler createCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();

        [HttpPost]
        public async Task<IActionResult> Create(CreateFunctionCommand command) =>
            Ok(await _createCommandHandler.CreateInstructor(command));
    }
}
