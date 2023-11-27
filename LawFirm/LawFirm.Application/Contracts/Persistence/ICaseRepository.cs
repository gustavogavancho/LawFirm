using LawFirm.Domain.Entities;

namespace LawFirm.Application.Contracts.Persistence;

public interface ICaseRepository : IAsyncRepository<Case>
{
    Task<List<Case>> FindCaseBySearchTerm(string searchTerm);
}