using LawFirm.App.ViewModels;

namespace LawFirm.App.Contracts;

public interface IClientDataService
{
    Task<ClientViewModel> CreateClient(CreateClientViewModel request);
    Task<List<ClientViewModel>> GetClients();
    Task<CreateClientViewModel> GetClient(Guid id);
    Task UpdateClient(Guid id, CreateClientViewModel request);
}