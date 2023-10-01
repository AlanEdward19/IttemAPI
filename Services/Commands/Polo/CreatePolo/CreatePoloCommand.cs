namespace Services.Commands.Polo.CreatePolo;

public class CreatePoloCommand
{
    public string Name { get; set; }

    public Domain.Entities.Polo ToEntity()
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = this.Name
        };
    }
}