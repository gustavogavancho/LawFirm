using LawFirm.Domain.Entities;

namespace LawFirm.Application.Contracts.Persistence;

public interface ICourtCaseRepository : IAsyncRepository<CourtCase>
{
}