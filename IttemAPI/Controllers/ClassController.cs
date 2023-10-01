using Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Class.CreateClass;
using Services.Queries.Class.GetClass;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly CreateClassCommandHandler _createCommandHandler;
        private readonly GetClassQueryHandler _queryHandler;

        public ClassController(CreateClassCommandHandler createCommandHandler, GetClassQueryHandler queryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? instructorId) => Ok(await _queryHandler.Get(instructorId));

        [HttpPost]
        public async Task<IActionResult> Create(CreateClassCommand command) =>
            Ok(await _createCommandHandler.CreateClass(command));
    }
}
