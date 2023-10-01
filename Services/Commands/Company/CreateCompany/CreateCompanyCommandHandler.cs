using Infrastructure.Context;

namespace Services.Commands.Company.CreateCompany;

public class CreateCompanyCommandHandler
{
    private readonly IttemContext _dbContext;

    public CreateCompanyCommandHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<dynamic> CreateCompany(CreateCompanyCommand command)
    {
        var parsedEntity = command.ToEntity();
        await _dbContext.Companies.AddAsync(parsedEntity);

        await _dbContext.SaveChangesAsync();

        return new
        {
            parsedEntity.Cnpj,
            Company = parsedEntity.Name
        };
    }
}