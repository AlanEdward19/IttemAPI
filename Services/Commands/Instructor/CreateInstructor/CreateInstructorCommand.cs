using Domain.Entities;
using Infrastructure.Context;

namespace Services.Commands.Instructor.CreateInstructor;

public class CreateInstructorCommand
{
    public string Name { get; set; }
    public string PhotoPath { get; set; }
    public List<Guid>? ClassesId { get; set; }


    public Domain.Entities.Instructor ToEntity(IttemContext context)
    {
        var classes = ClassesId != null && ClassesId.Any()
            ? context.Classes.Where(x => ClassesId.Contains(x.Id)).ToList()
            : null;

        return new()
        {
            Id = Guid.NewGuid(),
            Name = this.Name,
            PhotoPath = this.PhotoPath,
            Classes = classes
        };
    }
}