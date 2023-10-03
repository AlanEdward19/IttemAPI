using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "admin, worker")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        private readonly CreateFunctionCommandHandler _createCommandHandler;
        private readonly GetFunctionQueryHandler _queryHandler;

        public FunctionController(CreateFunctionCommandHandler createCommandHandler, GetFunctionQueryHandler queryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? id) => Ok(await _queryHandler.Get(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateFunctionCommand command) =>
            Ok(await _createCommandHandler.CreateInstructor(command));
    }
}
