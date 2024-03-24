using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Cases.Commands.UpdateCase;

public class UpdateCaseCommandHandler : IRequestHandler<UpdateCaseCommand>
{
    private readonly IMapper _mapper;
    private readonly ICaseRepository _caseRepository;
    private readonly IClientRepository _clientRepository;

    public UpdateCaseCommandHandler(IMapper mapper,
        ICaseRepository caseRepository,
        IClientRepository clientRepository)
    {
        _mapper = mapper;
        _caseRepository = caseRepository;
        _clientRepository = clientRepository;
    }

    public async Task Handle(UpdateCaseCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCaseCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        var existingCase = await _caseRepository.GetByIdAsync(request.Id, false, x => x.Clients, x => x.CounterParts, x => x.Events, x=> x.Charges, x=> x.Notifications, x => x.Statuses, x => x.Notes);

        if (existingCase == null)
        {
            throw new NotFoundException(nameof(Case), "Case not found.");
        }

        _mapper.Map(request, existingCase);

        existingCase.Clients.Clear();
        request.Ids.ForEach(async id =>
        {
            existingCase.Clients.Add(await _clientRepository.GetByIdAsync(id, false));
        });

        await _caseRepository.Save();
    }
}