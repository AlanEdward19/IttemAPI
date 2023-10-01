using Infrastructure.Context;

namespace Services.Commands.Polo.CreatePolo;

public class CreatePoloCommandHandler
{
    private readonly IttemContext _dbContext;

    public CreatePoloCommandHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<dynamic> CreatePolo(CreatePoloCommand command)
    {
        var parsedEntity = command.ToEntity();
        await _dbContext.Polos.AddAsync(parsedEntity);

        await _dbContext.SaveChangesAsync();

        return new
        {
            parsedEntity.Id,
            Polo = parsedEntity.Name
        };
    }
}