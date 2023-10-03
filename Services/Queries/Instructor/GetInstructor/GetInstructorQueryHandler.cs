using Microsoft.EntityFrameworkCore;

namespace Services.Queries.Instructor.GetInstructor;

public class GetInstructorQueryHandler
{
    private readonly IttemContext _dbContext;
    private readonly IAuthService _authService;

    public GetInstructorQueryHandler(IttemContext dbContext, IAuthService authService)
    {
        _dbContext = dbContext;
        _authService = authService;
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
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                PhotoPath = instructor.PhotoPath
            });
        }

        return result;
    }

    public async Task<Domain.Entities.Instructor> GetByEmailAndPassword(string email, string password)
    {
        var database = await _dbContext.Instructors.FirstAsync(x =>
            x.Email.ToLower().Equals(email.ToLower()) && x.Password.Equals(password));

        return database;
    }
}