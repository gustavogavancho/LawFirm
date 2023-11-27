using LawFirm.App.Services.Base;

namespace LawFirm.App.Contracts;

public interface ICaseDataService
{
    Task<CaseVmPagingResponse> GetCases(int? pageNumber, int? pageSize);
    Task<CaseVm> GetCase(Guid id);
    Task<CaseVm> CreateCase(CaseVm request, List<Guid> ids);
    Task<ICollection<CaseVm>> FindCasesBySearchTerm(string searchTerm);
    Task UpdateCase(CaseVm request, List<Guid> ids);
    Task DeleteCase(Guid id);
}