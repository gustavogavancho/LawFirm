using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Clients.Commands.UpdateClient;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;

    public UpdateClientCommandHandler(IMapper mapper,
        IClientRepository clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }

    public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateClientCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        var clientToUpdate = await _clientRepository.GetByIdAsync(request.Id);

        if (clientToUpdate is null) throw new NotFoundException(nameof(Client), request.Id);

        _mapper.Map(request, clientToUpdate, typeof(UpdateClientCommand), typeof(Client));

        await _clientRepository.UpdateAsync(clientToUpdate);
    }
}