using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "admin, worker")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly CreateAttendanceCommandHandler _createCommandHandler;
        private readonly GetAttendanceQueryHandler _queryHandler;

        public AttendanceController(CreateAttendanceCommandHandler createCommandHandler, GetAttendanceQueryHandler queryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? studentId) => Ok(await _queryHandler.Get(studentId));

        [HttpPost]
        public async Task<IActionResult> Create(CreateAttendanceCommand command) =>
            Ok(await _createCommandHandler.CreateAttendance(command));
    }
}
