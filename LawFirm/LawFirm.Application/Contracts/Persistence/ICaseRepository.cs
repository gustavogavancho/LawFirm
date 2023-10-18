using LawFirm.Domain.Entities;

namespace LawFirm.Application.Contracts.Persistence;

public interface ICaseRepository : IAsyncRepository<Case>
{
    Task<List<Case>> GetCasesWithRelatedEntities();
    Task<Case> GetCaseWithRelatedEntities(Guid id);
}