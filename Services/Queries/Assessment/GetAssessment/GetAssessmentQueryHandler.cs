using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Services.ViewModels;

namespace Services.Queries.Assessment.GetAssessment;

public class GetAssessmentQueryHandler
{
    private readonly IttemContext _dbContext;

    public GetAssessmentQueryHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<AssessmentViewModel>> Get(string? studentId)
    {
        List<AssessmentViewModel> result = new();
        var database = string.IsNullOrWhiteSpace(studentId)
            ? await _dbContext.Assessments.Include(x => x.Student).ToListAsync()
            : await _dbContext.Assessments.Include(x => x.Student).Where(x => x.StudentId.Equals(studentId))
                .ToListAsync();

        foreach (var assessment in database)
        {
            result.Add(new()
            {
                Id = assessment.Id,
                StudentId = assessment.StudentId,
                Level = assessment.Level,
                GoalFulfillment = assessment.GoalFulfillment,
                InterpersonalRelationship = assessment.InterpersonalRelationship,
                Module = assessment.Module,
                Participation = assessment.Participation,
                SkillTechnique = assessment.SkillTechnique,
                StudentName = assessment.Student.Name
            });
        }

        return result;
    }
}