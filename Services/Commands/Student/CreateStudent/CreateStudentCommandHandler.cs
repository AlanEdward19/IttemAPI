using Infrastructure.Context;

namespace Services.Commands.Student.CreateStudent;

public class CreateStudentCommandHandler
{
    private readonly IttemContext _dbContext;

    public CreateStudentCommandHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<dynamic> CreateStudent(CreateStudentCommand command)
    {
        var parsedEntity = command.ToEntity();
        await _dbContext.Students.AddAsync(parsedEntity);

        await _dbContext.SaveChangesAsync();

        return new
        {
            parsedEntity.Cpf,
            Student = parsedEntity.Name
        };
    }
}