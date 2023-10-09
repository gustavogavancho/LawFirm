using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Cases.Commands.DeleteCase;

public class DeleteCaseComandHandler : IRequestHandler<DeleteCaseCommand>
{
    private readonly ICaseRepository _caseRepository;

    public DeleteCaseComandHandler(ICaseRepository caseRepository)
    {
        _caseRepository = caseRepository;
    }

    public async Task Handle(DeleteCaseCommand request, CancellationToken cancellationToken)
    {
        var clientToDelete = await _caseRepository.GetByIdAsync(request.ClientId);

        if (clientToDelete == null)
        {
            throw new NotFoundException(nameof(Case), request.ClientId);
        }

        await _caseRepository.DeleteAsync(clientToDelete);
    }
}