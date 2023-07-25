using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetClientList;

public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, List<ClientListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Client> _clientRepository;

    public GetClientListQueryHandler(IMapper mapper,
        IAsyncRepository<Client> clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }

    public async Task<List<ClientListVm>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
    {
        var allEvents = (await _clientRepository.ListAllAsync()).OrderBy(x => x.Name);

        return _mapper.Map<List<ClientListVm>>(allEvents);
    }
}