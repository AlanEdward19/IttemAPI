using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Instructor.CreateInstructor;
using Services.Queries.Instructor.GetInstructor;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly CreateInstructorCommandHandler _createCommandHandler;
        private readonly GetInstructorQueryHandler _queryHandler;

        public InstructorController(CreateInstructorCommandHandler createCommandHandler, GetInstructorQueryHandler queryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? id) => Ok(await _queryHandler.Get(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInstructorCommand command) =>
            Ok(await _createCommandHandler.CreateInstructor(command));
    }
}
