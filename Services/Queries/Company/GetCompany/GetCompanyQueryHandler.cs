using Microsoft.EntityFrameworkCore;

namespace Services.Queries.Company.GetCompany;

public class GetCompanyQueryHandler
{
    private readonly IttemContext _dbContext;

    public GetCompanyQueryHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CompanyViewModel>> Get(string? cnpj)
    {
        List<CompanyViewModel> result = new();
        var database = string.IsNullOrWhiteSpace(cnpj)
            ? await _dbContext.Companies.ToListAsync()
            : await _dbContext.Companies.Where(x => x.Cnpj.Equals(cnpj))
                .ToListAsync();

        foreach (var company in database)
        {
            result.Add(new()
            {
                Name = company.Name,
                Cnpj = company.Cnpj
            });
        }

        return result;
    }
}