using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Assessment.CreateAssessment;
using Services.Queries.Assessment.GetAssessment;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly CreateAssessmentCommandHandler _createCommandHandler;
        private readonly GetAssessmentQueryHandler _queryHandler;

        public AssessmentController(CreateAssessmentCommandHandler createCommandHandler, GetAssessmentQueryHandler queryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? studentId) => Ok(await _queryHandler.Get(studentId));

        [HttpPost]
        public async Task<IActionResult> Create(CreateAssessmentCommand command) =>
            Ok(await _createCommandHandler.CreateAssessment(command));
    }
}
