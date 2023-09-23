using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;

namespace LawFirm.Persistence.Repositories;

public class CourtCaseRepository : BaseRepository<Case>, ICourtCaseRepository
{
    public CourtCaseRepository(LawFirmContext dbContext) : base(dbContext)
    {
    }
}