using LawFirm.App.Services.Base;

namespace LawFirm.App.Contracts;

public interface IClientDataService
{
    Task<ClientVm> CreateClient(CreateClientCommand request);
    Task<ClientVmPagingResponse> GetClients(int? pageNumber, int? pageSize);
    Task<ICollection<ClientVm>> FindClientsBySearchTerm(string searchTerm);
    Task<ClientVm> GetClient(Guid id);
    Task UpdateClient(Guid id, UpdateClientCommand request);
    Task DeleteClient(Guid id);
}