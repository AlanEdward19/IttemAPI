using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Services.ViewModels;

namespace Services.Queries.Polo.GetPolo;

public class GetPoloQueryHandler
{
    private readonly IttemContext _dbContext;

    public GetPoloQueryHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PoloViewModel>> Get(string? id)
    {
        List<PoloViewModel> result = new();
        var database = string.IsNullOrWhiteSpace(id)
            ? await _dbContext.Polos.ToListAsync()
            : await _dbContext.Polos.Where(x => x.Id.Equals(Guid.Parse(id)))
                .ToListAsync();

        foreach (var polo in database)
        {
            result.Add(new()
            {
                Id = polo.Id,
                Name = polo.Name
            });
        }

        return result;
    }
}