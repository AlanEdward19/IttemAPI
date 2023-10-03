using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Services.ViewModels;

namespace Services.Queries.Class.GetClass;

public class GetClassQueryHandler
{
    private readonly IttemContext _dbContext;

    public GetClassQueryHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ClassViewModel>> Get(string? instructorId)
    {
        List<ClassViewModel> result = new();
        var database = string.IsNullOrWhiteSpace(instructorId)
            ? await _dbContext.Classes.Include(x => x.Instructor).ToListAsync()
            : await _dbContext.Classes.Include(x => x.Instructor).Where(x => x.InstructorId.Equals(Guid.Parse(instructorId)))
                .ToListAsync();

        foreach (var @class in database)
        {
            result.Add(new()
            {
                Id = @class.Id,
                InstructorId = @class.InstructorId,
                InstructorName = $"{@class.Instructor.FirstName} {@class.Instructor.LastName}",
                Name = @class.Name
            });
        }

        return result;
    }
}