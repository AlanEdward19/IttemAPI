namespace Services.Commands.Class.CreateClass;

public class CreateClassCommandHandler
{
    private readonly IttemContext _dbContext;

    public CreateClassCommandHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<dynamic> CreateClass(CreateClassCommand command)
    {
        var parsedEntity = command.ToEntity();
        await _dbContext.Classes.AddAsync(parsedEntity);

        await _dbContext.SaveChangesAsync();

        return new
        {
            Operation = "Create",
            parsedEntity.Id,
            Class = parsedEntity.Name
        };
    }
}