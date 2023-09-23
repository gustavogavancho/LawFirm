using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;

namespace LawFirm.Persistence.Repositories;

public class CaseRepository : BaseRepository<Case>, ICaseRepository
{
    public CaseRepository(LawFirmContext dbContext) : base(dbContext)
    {
    }
}