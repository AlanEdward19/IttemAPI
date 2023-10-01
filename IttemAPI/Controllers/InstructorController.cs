using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Instructor.CreateInstructor;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly CreateInstructorCommandHandler _createCommandHandler;

        public InstructorController(CreateInstructorCommandHandler createCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInstructorCommand command) =>
            Ok(await _createCommandHandler.CreateInstructor(command));
    }
}
