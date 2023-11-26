using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawFirm.Persistence.Repositories;

public class CaseRepository : BaseRepository<Case>, ICaseRepository
{
    public CaseRepository(LawFirmContext dbContext) : base(dbContext) { }
}