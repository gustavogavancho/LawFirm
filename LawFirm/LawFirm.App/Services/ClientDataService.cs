using AutoMapper;
using Blazored.LocalStorage;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;
using LawFirm.App.ViewModels;

namespace LawFirm.App.Services;

public class ClientDataService : BaseDataService, IClientDataService
{
    private readonly IMapper _mapper;

    public ClientDataService(IClient client, IMapper mapper, ILocalStorageService localStorage)
        : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<ClientViewModel> CreateClient(CreateClientViiewModel request)
    {
        var requestMapped = _mapper.Map<CreateClientCommand>(request);

        var response = await _client.CreateClientAsync(requestMapped);

        var responseMapped = _mapper.Map<ClientViewModel>(response);

        return responseMapped;
    }

    public async Task<List<ClientViewModel>> GetClients()
    {
        var allClients = await _client.GetClientsAsync();

        var mappedClients = _mapper.Map<List<ClientViewModel>>(allClients);

        return mappedClients;
    }

    public async Task<ClientViewModel> GetClient(Guid id)
    {
        var selectedClient = await _client.GetClientAsync(id);

        var mappedClient = _mapper.Map<ClientViewModel>(selectedClient);

        return mappedClient;
    }
}