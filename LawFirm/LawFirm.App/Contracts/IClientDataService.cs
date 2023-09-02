using LawFirm.App.ViewModels;

namespace LawFirm.App.Contracts;

public interface IClientDataService
{
    Task<ClientViewModel> CreateClient(CreateClientViiewModel request);
    Task<List<ClientViewModel>> GetClients();
    Task<ClientViewModel> GetClient(Guid id);
}