using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly CreateInstructorCommandHandler _createCommandHandler;
        private readonly GetInstructorQueryHandler _queryHandler;
        private readonly LoginQueryHandler _loginHandler;

        public InstructorController(CreateInstructorCommandHandler createCommandHandler, GetInstructorQueryHandler queryHandler, LoginQueryHandler loginHandler)
        {
            _createCommandHandler = createCommandHandler;
            _queryHandler = queryHandler;
            _loginHandler = loginHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? id) => Ok(await _queryHandler.Get(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInstructorCommand command) =>
            Ok(await _createCommandHandler.CreateInstructor(command));

        [HttpGet("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] LoginQuery query, CancellationToken cancellationToken) =>
            Ok(await _loginHandler.Handle(query, cancellationToken));
    }
}
