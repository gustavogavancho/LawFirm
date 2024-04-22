using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Clients.Models;
using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetLatestClients;

public class GetLatestClientsQueryHandler : IRequestHandler<GetLatestClientsQuery, List<ClientVm>>
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;

    public GetLatestClientsQueryHandler(IMapper mapper,
        IClientRepository clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }

    public async Task<List<ClientVm>> Handle(GetLatestClientsQuery request, CancellationToken cancellationToken)
    {
        var pagedItems = await _clientRepository.GetLastestClients();

        var mappedItems = _mapper.Map<List<ClientVm>>(pagedItems);

        return mappedItems;
    }
}