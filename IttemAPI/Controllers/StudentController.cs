using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Student.CreateStudent;
using Services.Queries.Student.GetStudent;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CreateStudentCommandHandler _createCommandHandler;
        private readonly GetStudentQueryHandler _queryHandler;

        public StudentController(CreateStudentCommandHandler createCommandHandler, GetStudentQueryHandler queryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? cpf) => Ok(await _queryHandler.Get(cpf));

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command) =>
            Ok(await _createCommandHandler.CreateStudent(command));
    }
}
