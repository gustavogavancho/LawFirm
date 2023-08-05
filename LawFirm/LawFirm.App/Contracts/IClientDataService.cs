using LawFirm.App.ViewModels;

namespace LawFirm.App.Contracts;

public interface IClientDataService
{
    Task<List<ClientViewModel>> GetAllClients();
    Task<ClientViewModel> GetClientById(Guid id);
}