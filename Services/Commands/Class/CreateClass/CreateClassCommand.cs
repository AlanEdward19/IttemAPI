namespace Services.Commands.Class.CreateClass;

public class CreateClassCommand
{
    public string Name { get; set; }
    public Guid InstructorId { get; set; }

    public Domain.Entities.Class ToEntity()
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = this.Name,
            InstructorId = InstructorId
        };
    }
}