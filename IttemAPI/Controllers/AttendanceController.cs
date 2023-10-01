using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Attendance.CreateAttendance;
using Services.Queries.Attendance.GetAttendance;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
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
