using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Clients.Commands.CreateClient;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;

    public CreateClientCommandHandler(IMapper mapper,
        IClientRepository clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }

    public async Task<CreateClientCommandResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var createClientCommandResponse = new CreateClientCommandResponse();

        var validator = new CreateClientCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            createClientCommandResponse.Success = false;
            createClientCommandResponse.ValidationErrors = new List<string>();
            validationResult.Errors.ForEach(e => createClientCommandResponse.ValidationErrors.Add(e.ErrorMessage));
        }

        if (createClientCommandResponse.Success)
        {
            var @client = _mapper.Map<Client>(request);
            @client = await _clientRepository.AddAsync(@client);
            createClientCommandResponse.Client = _mapper.Map<CreateClientDto>(@client);
        }

        return createClientCommandResponse;
    }
}