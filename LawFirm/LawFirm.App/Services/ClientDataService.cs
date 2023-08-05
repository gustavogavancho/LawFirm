using AutoMapper;
using Blazored.LocalStorage;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;
using LawFirm.App.ViewModels;

namespace LawFirm.App.Services;

public class ClientDataService : BaseDataService, IClientDataService
{
    private readonly IMapper _mapper;

    public ClientDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<List<ClientViewModel>> GetAllClients()
    {
        await AddBearerToken();

        var allClients = await _client.GetAllClientsAsync();
        var mappedClients = _mapper.Map<List<ClientViewModel>>(allClients);
        return mappedClients;
    }

    public async Task<ClientViewModel> GetClientById(Guid id)
    {
        await AddBearerToken();

        var selectedClient = await _client.GetClientByIdAsync(id);
        var mappedClient = _mapper.Map<ClientViewModel>(selectedClient);
        return mappedClient;
    }
}