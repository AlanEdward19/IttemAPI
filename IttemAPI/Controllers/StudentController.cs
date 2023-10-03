using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Student.CreateStudent;
using Services.Commands.Student.DeleteStudent;
using Services.Queries.Student.GetStudent;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "admin, worker")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CreateStudentCommandHandler _createCommandHandler;
        private readonly UpdateStudentCommandHandler _updateCommandHandler;
        private readonly DeleteStudentCommandHandler _deleteCommandHandler;
        private readonly GetStudentQueryHandler _queryHandler;

        public StudentController(CreateStudentCommandHandler createCommandHandler, UpdateStudentCommandHandler updateCommandHandler, DeleteStudentCommandHandler deleteCommandHandler, GetStudentQueryHandler queryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _updateCommandHandler = updateCommandHandler;
            _deleteCommandHandler = deleteCommandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? cpf) => Ok(await _queryHandler.Get(cpf));

        [HttpGet("byClass")]
        public async Task<IActionResult> GetByClass(string? classId) =>
            Ok(await _queryHandler.GetStudentByClass(classId));

        [HttpDelete]
        public async Task<IActionResult> Delete(string cpf) => Ok(await _deleteCommandHandler.Delete(cpf));

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command) =>
            Ok(await _createCommandHandler.CreateStudent(command));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCommand command, [FromQuery] string cpf) =>
            Ok(await _updateCommandHandler.UpdateStudent(command, cpf));
    }
}
