using LawFirm.App.Services.Base;

namespace LawFirm.App.Contracts;

public interface ICaseDataService
{
    Task<ICollection<CaseVm>> GetAllCases();
    Task<CaseVm> GetCase(Guid id);
    Task<CaseVm> CreateCase(CaseVm request, List<Guid> ids);
    Task UpdateCase(CaseVm request, List<Guid> ids);
    Task DeleteCase(Guid id);
}