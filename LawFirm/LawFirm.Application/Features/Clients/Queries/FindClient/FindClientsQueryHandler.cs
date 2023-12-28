using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Application.Features.Clients.Models;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetClientDetail;

public class FindClientsQueryHandler : IRequestHandler<FindClientsQuery, List<ClientVm>>
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;

    public FindClientsQueryHandler(IMapper mapper,
        IClientRepository clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }

    public async Task<List<ClientVm>> Handle(FindClientsQuery request, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.FindCliendBySearchTerm(request.SearchTerm);

        if (client == null) 
            throw new NotFoundException(nameof(Client), request.SearchTerm);

        var clientDetailDto = _mapper.Map<List<ClientVm>>(client);

        return clientDetailDto;
    }
}