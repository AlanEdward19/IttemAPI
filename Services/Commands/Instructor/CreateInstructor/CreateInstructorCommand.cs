using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.Context;
using Services.Auth;

namespace Services.Commands.Instructor.CreateInstructor;

public class CreateInstructorCommand
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhotoPath { get; set; }
    public ERole Role { get; set; }
    public List<Guid>? ClassesId { get; set; }

    public Domain.Entities.Instructor ToEntity(IttemContext context, IAuthService authService)
    {
        var classes = ClassesId != null && ClassesId.Any()
            ? context.Classes.Where(x => ClassesId.Contains(x.Id)).ToList()
            : null;

        return new()
        {
            Id = Guid.NewGuid(),
            Email = this.Email,
            Password = authService.ComputeSha256Hash(this.Password),
            FirstName = this.FirstName,
            LastName = this.LastName,
            Role = this.Role.ToString(),
            PhotoPath = this.PhotoPath,
            Classes = classes
        };
    }
}