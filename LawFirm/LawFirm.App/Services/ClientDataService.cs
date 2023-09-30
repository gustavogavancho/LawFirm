using Blazored.LocalStorage;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Services;

public class ClientDataService : BaseDataService, IClientDataService
{
    public ClientDataService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {
        
    }

    public async Task<ClientVm> CreateClient(CreateClientCommand request)
    {
        try
        {
            var response = await _client.CreateClientAsync(request);

            return response;
        }
        catch (Exception ex)
        {
            var check = ex.InnerException;
            var check1 = ex.Message;
            throw;
        }


    }

    public async Task<ClientVmPagingResponse> GetClients(int? pageNumber, int? pageSize)
    {
        var pagedClients = await _client.GetClientsAsync(pageNumber, pageSize);

        return pagedClients;
    }

    public async Task<ClientVm> GetClient(Guid id)
    {
        var selectedClient = await _client.GetClientAsync(id);

        return selectedClient;
    }

    public async Task UpdateClient(Guid id, UpdateClientCommand request)
    {
        request.Id = id;

        await _client.UpdateClientAsync(request);
    }

    public async Task DeleteClient(Guid id)
    {
        await _client.DeleteClientAsync(id);
    }

    public async Task<ICollection<ClientVm>> FindClientsBySearchTerm(string searchTerm)
    {
        return await _client.FindClientsBySearchTermAsync(searchTerm);
    }
}