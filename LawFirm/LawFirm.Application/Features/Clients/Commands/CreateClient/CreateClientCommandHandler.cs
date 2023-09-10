using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Clients.Models;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Clients.Commands.CreateClient;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ClientVm>
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;

    public CreateClientCommandHandler(IMapper mapper,
        IClientRepository clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }

    public async Task<ClientVm> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateClientCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if(validationResult.Errors.Count > 0)
            throw new Exceptions.ValidationException(validationResult);

        var @client = _mapper.Map<Client>(request);
        @client = await _clientRepository.AddAsync(@client);

        return _mapper.Map<ClientVm>(@client);
    }
}