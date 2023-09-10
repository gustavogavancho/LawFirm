using LawFirm.App.Services.Base;
using LawFirm.App.ViewModels;

namespace LawFirm.App.Contracts;

public interface IClientDataService
{
    Task<CreateClientDto> CreateClient(CreateClientCommand request);
    Task<ICollection<ClientListVm>> GetClients();
    Task<ClientDetailVm> GetClient(Guid id);
    Task UpdateClient(Guid id, UpdateClientCommand request);
    Task DeleteClient(Guid id);
}