namespace Services.Commands.Instructor.CreateInstructor;

public class CreateInstructorCommandHandler
{
    private readonly IttemContext _dbContext;
    private readonly IAuthService _authService;

    public CreateInstructorCommandHandler(IttemContext dbContext, IAuthService authService)
    {
        _dbContext = dbContext;
        _authService = authService;
    }

    public async Task<dynamic> CreateInstructor(CreateInstructorCommand command)
    {
        var parsedEntity = command.ToEntity(_dbContext, _authService);
        await _dbContext.Instructors.AddAsync(parsedEntity);

        await _dbContext.SaveChangesAsync();

        return new
        {
            Operation = "Create",
            parsedEntity.Id,
            Instructor = $"{parsedEntity.FirstName} {parsedEntity.LastName}",
            parsedEntity.Role
        };
    }
}