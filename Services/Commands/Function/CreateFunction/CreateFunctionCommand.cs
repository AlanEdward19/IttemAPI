namespace Services.Commands.Function.CreateFunction;

public class CreateFunctionCommand
{
    public string Name { get; set; }

    public Domain.Entities.Function ToEntity()
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = this.Name
        };
    }
}