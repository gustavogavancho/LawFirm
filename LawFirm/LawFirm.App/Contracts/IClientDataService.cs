using LawFirm.App.ViewModels;

namespace LawFirm.App.Contracts;

public interface IClientDataService
{
    Task<List<ClientViewModel>> GetAllCliennts();
}