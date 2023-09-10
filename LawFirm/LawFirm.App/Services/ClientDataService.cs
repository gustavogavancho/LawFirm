using Blazored.LocalStorage;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Services;

public class ClientDataService : BaseDataService, IClientDataService
{
    public ClientDataService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {
        
    }

    public async Task<CreateClientDto> CreateClient(CreateClientCommand request)
    {
        var response = await _client.CreateClientAsync(request);

        return response;
    }

    public async Task<ICollection<ClientListVm>> GetClients()
    {
        var allClients = await _client.GetClientsAsync();

        return allClients;
    }

    public async Task<ClientDetailVm> GetClient(Guid id)
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
}