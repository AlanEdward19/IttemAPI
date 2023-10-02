using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Assessment.CreateAssessment;
using Services.Commands.Assessment.DeleteAssessment;
using Services.Queries.Assessment.GetAssessment;

namespace IttemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly CreateAssessmentCommandHandler _createCommandHandler;
        private readonly GetAssessmentQueryHandler _queryHandler;
        private readonly DeleteAssessmentCommandHandler _deleteCommandHandler;

        public AssessmentController(CreateAssessmentCommandHandler createCommandHandler, GetAssessmentQueryHandler queryHandler, DeleteAssessmentCommandHandler deleteCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
            _queryHandler = queryHandler;
            _deleteCommandHandler = deleteCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? studentId) => Ok(await _queryHandler.Get(studentId));

        [HttpDelete]
        public async Task<IActionResult> Delete(string id) => Ok(await _deleteCommandHandler.DeleteAssessment(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateAssessmentCommand command) =>
            Ok(await _createCommandHandler.CreateAssessment(command));
    }
}
