using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Application.Features.Clients.Models;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetClientDetail;

public class GetEventDetailQueryHandler : IRequestHandler<GetClientDetailQuery, ClientVm>
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;

    public GetEventDetailQueryHandler(IMapper mapper,
        IClientRepository clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }

    public async Task<ClientVm> Handle(GetClientDetailQuery request, CancellationToken cancellationToken)
    {
        var @client = await _clientRepository.GetByIdAsync(request.Id);

        if(@client == null)
        {
            throw new NotFoundException(nameof(Client), request.Id);
        }

        var clientDetailDto = _mapper.Map<ClientVm>(@client);

        return clientDetailDto;
    }
}