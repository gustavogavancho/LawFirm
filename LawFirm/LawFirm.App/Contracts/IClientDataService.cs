using LawFirm.App.Services.Base;

namespace LawFirm.App.Contracts;

public interface IClientDataService
{
    Task<ClientVm> CreateClient(CreateClientCommand request);
    Task<ICollection<ClientVm>> GetClients();
    Task<ClientVm> GetClient(Guid id);
    Task UpdateClient(Guid id, UpdateClientCommand request);
    Task DeleteClient(Guid id);
}