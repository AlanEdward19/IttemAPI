using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Services.Commands.Assessment.DeleteAssessment;

public class DeleteAssessmentCommandHandler
{
    private readonly IttemContext _dbContext;

    public DeleteAssessmentCommandHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<dynamic> DeleteAssessment(string? id)
    {
        var assessment = await _dbContext.Assessments.FirstAsync(x => x.Id.Equals(Guid.Parse(id)));
        _dbContext.Assessments.Remove(assessment);

        await _dbContext.SaveChangesAsync();

        return new
        {
            Operation = "Delete",
            AssessmentId = assessment.Id,
            StudentId = assessment.StudentId
        };
    }
}