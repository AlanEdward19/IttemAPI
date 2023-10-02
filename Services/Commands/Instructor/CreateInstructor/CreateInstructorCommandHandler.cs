using Infrastructure.Context;

namespace Services.Commands.Instructor.CreateInstructor;

public class CreateInstructorCommandHandler
{
    private readonly IttemContext _dbContext;

    public CreateInstructorCommandHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<dynamic> CreateInstructor(CreateInstructorCommand command)
    {
        var parsedEntity = command.ToEntity(_dbContext);
        await _dbContext.Instructors.AddAsync(parsedEntity);

        await _dbContext.SaveChangesAsync();

        return new
        {
            Operation = "Create",
            parsedEntity.Id,
            Instructor = parsedEntity.Name
        };
    }
}