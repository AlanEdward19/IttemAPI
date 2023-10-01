using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Assessment.CreateAssessment;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly CreateAssessmentCommandHandler _createCommandHandler;

        public AssessmentController(CreateAssessmentCommandHandler createCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();

        [HttpPost]
        public async Task<IActionResult> Create(CreateAssessmentCommand command) =>
            Ok(await _createCommandHandler.CreateAssessment(command));
    }
}
