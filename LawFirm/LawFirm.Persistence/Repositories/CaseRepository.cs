using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawFirm.Persistence.Repositories;

public class CaseRepository : BaseRepository<Case>, ICaseRepository
{
    public CaseRepository(LawFirmContext dbContext) : base(dbContext) { }

    public async Task<List<Case>> FindCaseBySearchTerm(string searchTerm)
    {
        var isNumber = long.TryParse(searchTerm, out var number);

        var cases = !isNumber ? await _dbContext.Case.Where(x => x.Clients.Any(y => y.FirstName.ToLower().Contains(searchTerm.ToLower()) || y.LastName.ToLower().Contains(searchTerm.ToLower()) || y.BusinessName.ToLower().Contains(searchTerm.ToLower())) ||
                                                            x.CounterParts.Any(y => y.Name.ToLower().Contains(searchTerm.ToLower())) ||
                                                            x.FileNumber.ToLower().Contains(searchTerm.ToLower()))
            .Include(x => x.Clients)
            .Include(x => x.CounterParts)
            .AsNoTracking()
            .ToListAsync()

            : await _dbContext.Case.Where(x => x.Clients.Any(y => y.Nit == number))
            .Include(x => x.Clients)
            .Include(x => x.CounterParts)
            .AsNoTracking()
            .ToListAsync();

        return cases;
    }

    public async Task<List<Case>> GetLatestCases()
    {
        var cases = await _dbContext.Case.OrderByDescending(x => x.CreatedDate)
            .Include(x => x.Clients)
            .Include(x => x.CounterParts)
            .Take(4)
            .ToListAsync();

        return cases;
    }
}