using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Application.Features.Cases.Commands.CreateCase;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Cases.Commands.UpdateCase;

public class UpdateCaseCommandHandler : IRequestHandler<UpdateCaseCommand>
{
    private readonly IMapper _mapper;
    private readonly ICaseRepository _caseRepository;
    private readonly IClientCaseRepository _clientCaseRepository;
    private readonly ICounterPartRepository _counterPartRepository;

    public UpdateCaseCommandHandler(IMapper mapper,
        ICaseRepository caseRepository,
        IClientCaseRepository clientCaseRepository,
        ICounterPartRepository counterPartRepository)
    {
        _mapper = mapper;
        _caseRepository = caseRepository;
        _clientCaseRepository = clientCaseRepository;
        _counterPartRepository = counterPartRepository;
    }

    public async Task Handle(UpdateCaseCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCaseCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        var existingCase = await _caseRepository.GetByIdAsync(request.Id, x => x.Clients, x=> x.CounterParts);

        if (existingCase == null)
        {
            throw new NotFoundException(nameof(Case),"Case not found.");
        }

        _mapper.Map(request, existingCase);

        await _caseRepository.UpdateAsync(existingCase, x=> x.Clients, x=> x.CounterParts);
    }
}