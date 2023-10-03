using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Services.ViewModels;

namespace Services.Queries.Function.GetFunction;

public class GetFunctionQueryHandler
{
    private readonly IttemContext _dbContext;

    public GetFunctionQueryHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<FunctionViewModel>> Get(string? id)
    {
        List<FunctionViewModel> result = new();
        var database = string.IsNullOrWhiteSpace(id)
            ? await _dbContext.Functions.ToListAsync()
            : await _dbContext.Functions.Where(x => x.Id.Equals(Guid.Parse(id)))
                .ToListAsync();

        foreach (var function in database)
        {
            result.Add(new()
            {
                Id = function.Id,
                Name = function.Name
            });
        }

        return result;
    }
}