using Infrastructure.Context;

namespace Services.Commands.Student.CreateStudent;

public class UpdateStudentCommandHandler
{
    private readonly IttemContext _dbContext;

    public UpdateStudentCommandHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<dynamic> UpdateStudent(UpdateStudentCommand command, string cpf)
    {
        var parsedEntity = await command.ToEntity(_dbContext, cpf);

        await _dbContext.SaveChangesAsync();

        return new
        {
            Operation = "Update",
            parsedEntity.Cpf,
            Student = parsedEntity.Name
        };
    }
}