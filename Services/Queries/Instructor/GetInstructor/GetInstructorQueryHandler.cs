using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Services.ViewModels;

namespace Services.Queries.Instructor.GetInstructor;

public class GetInstructorQueryHandler
{
    private readonly IttemContext _dbContext;

    public GetInstructorQueryHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<InstructorViewModel>> Get(string? id)
    {
        List<InstructorViewModel> result = new();
        var database = string.IsNullOrWhiteSpace(id)
            ? await _dbContext.Instructors.ToListAsync()
            : await _dbContext.Instructors.Where(x => x.Id.Equals(Guid.Parse(id)))
                .ToListAsync();

        foreach (var instructor in database)
        {
            result.Add(new()
            {
                Id = instructor.Id,
                Name = instructor.Name,
                PhotoPath = instructor.PhotoPath
            });
        }

        return result;
    }
}