using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Student.CreateStudent;
using Services.Commands.Student.DeleteStudent;
using Services.Queries.Student.GetStudent;
using System.Data;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "admin, worker")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CreateStudentCommandHandler _createCommandHandler;
        private readonly DeleteStudentCommandHandler _deleteCommandHandler;
        private readonly GetStudentQueryHandler _queryHandler;

        public StudentController(CreateStudentCommandHandler createCommandHandler, DeleteStudentCommandHandler deleteCommandHandler, GetStudentQueryHandler queryHandler)
        {
            _createCommandHandler = createCommandHandler;
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
    }
}
