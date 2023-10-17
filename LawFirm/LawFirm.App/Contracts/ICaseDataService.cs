using LawFirm.App.Services.Base;

namespace LawFirm.App.Contracts;

public interface ICaseDataService
{
    Task<CaseVm> CreateCase(CreateCaseCommand request);
    Task<ICollection<CaseVm>> GetAllCases();
    Task<CaseVm> GetCase(Guid id);
    Task DeleteCase(Guid id);
}