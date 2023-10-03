using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "admin, worker")]
    [ApiController]
    public class PoloController : ControllerBase
    {
        private readonly CreatePoloCommandHandler _createCommandHandler;
        private readonly GetPoloQueryHandler _queryHandler;

        public PoloController(CreatePoloCommandHandler createCommandHandler, GetPoloQueryHandler queryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? id) => Ok(await _queryHandler.Get(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreatePoloCommand command) =>
            Ok(await _createCommandHandler.CreatePolo(command));
    }
}
