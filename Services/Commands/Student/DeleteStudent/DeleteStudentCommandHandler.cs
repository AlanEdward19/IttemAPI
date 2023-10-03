using Microsoft.EntityFrameworkCore;

namespace Services.Commands.Student.DeleteStudent;

public class DeleteStudentCommandHandler
{
    private readonly IttemContext _dbContext;

    public DeleteStudentCommandHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<dynamic> Delete(string id)
    {
        var student = await _dbContext.Students.FirstAsync(x => x.Cpf.Equals(id));

        _dbContext.Students.Remove(student);

        await _dbContext.SaveChangesAsync();

        return new
        {
            Operation = "Delete",
            StudentId = student.Cpf
        };
    }
}