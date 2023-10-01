using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Attendance.CreateAttendance;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly CreateAttendanceCommandHandler _createCommandHandler;

        public AttendanceController(CreateAttendanceCommandHandler createCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();

        [HttpPost]
        public async Task<IActionResult> Create(CreateAttendanceCommand command) =>
            Ok(await _createCommandHandler.CreateAttendance(command));
    }
}
