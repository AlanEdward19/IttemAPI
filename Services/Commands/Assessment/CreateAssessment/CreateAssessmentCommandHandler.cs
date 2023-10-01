using Infrastructure.Context;

namespace Services.Commands.Assessment.CreateAssessment;

public class CreateAssessmentCommandHandler
{
    private readonly IttemContext _dbContext;

    public CreateAssessmentCommandHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<dynamic> CreateAssessment(CreateAssessmentCommand command)
    {
        var parsedEntity = command.ToEntity();
        await _dbContext.Assessments.AddAsync(parsedEntity);

        await _dbContext.SaveChangesAsync();

        return new
        {
            parsedEntity.Id
        };
    }
}