using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Student.CreateStudent;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CreateStudentCommandHandler _createCommandHandler;

        public StudentController(CreateStudentCommandHandler createCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command) =>
            Ok(await _createCommandHandler.CreateStudent(command));
    }
}
