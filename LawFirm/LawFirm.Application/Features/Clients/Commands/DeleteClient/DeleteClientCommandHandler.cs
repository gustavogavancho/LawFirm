using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Clients.Commands.DeleteClient;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
{
    private readonly IClientRepository _clientRepository;

    public DeleteClientCommandHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var clientToDelete = await _clientRepository.GetByIdAsync(request.ClientId);

        if (clientToDelete == null)
        {
            throw new NotFoundException(nameof(Client), request.ClientId);
        }

        await _clientRepository.DeleteAsync(clientToDelete);
    }
}