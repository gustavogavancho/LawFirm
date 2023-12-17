using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Clients.Models;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetClientList;

public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, List<ClientVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Client> _clientRepository;

    public GetClientListQueryHandler(IMapper mapper,
        IAsyncRepository<Client> clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }

    public async Task<List<ClientVm>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
    {
        var clients = (await _clientRepository.ListAllAsync(true)).OrderBy(x => x.FirstName);

        return _mapper.Map<List<ClientVm>>(clients);
    }
}