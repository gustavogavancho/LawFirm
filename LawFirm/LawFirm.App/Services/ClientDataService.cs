using AutoMapper;
using Blazored.LocalStorage;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Services;

public class ClientDataService : BaseDataService, IClientDataService
{
    private readonly IMapper _mapper;

    public ClientDataService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<ClientVm> CreateClient(ClientVm request)
    {
        var responseMapped = _mapper.Map<CreateClientCommand>(request);

        var response = await _client.CreateClientAsync(responseMapped);

        return response;
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

    public async Task UpdateClient(Guid id, ClientVm request)
    {
        var requestMapped = _mapper.Map<UpdateClientCommand>(request);

        requestMapped.Id = id;

        await _client.UpdateClientAsync(requestMapped);
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