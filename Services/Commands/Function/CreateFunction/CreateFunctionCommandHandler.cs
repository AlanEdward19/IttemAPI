using Infrastructure.Context;

namespace Services.Commands.Function.CreateFunction;

public class CreateFunctionCommandHandler
{
    private readonly IttemContext _dbContext;

    public CreateFunctionCommandHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<dynamic> CreateInstructor(CreateFunctionCommand command)
    {
        var parsedEntity = command.ToEntity();
        await _dbContext.Functions.AddAsync(parsedEntity);

        await _dbContext.SaveChangesAsync();

        return new
        {
            parsedEntity.Id,
            Function = parsedEntity.Name
        };
    }
}