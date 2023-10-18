using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawFirm.Persistence.Repositories;

public class CaseRepository : BaseRepository<Case>, ICaseRepository
{
    public CaseRepository(LawFirmContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<List<Case>> GetCasesWithRelatedEntities()
    {
        var result = await _dbContext.Case.Include(x => x.Clients)
            .Include(x => x.CounterParts)
            .AsNoTracking()
            .ToListAsync();

        return result;
    }

    public async Task<Case> GetCaseWithRelatedEntities(Guid id)
    {
        var result = await _dbContext.Case.Include(x => x.Clients)
            .Include(x => x.CounterParts)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return result;
    }
}