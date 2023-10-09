using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Application.Features.Cases.Models;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Cases.Commands.CreateCase;

public class CreateCaseCommandHandler : IRequestHandler<CreateCaseCommand, CaseVm>
{
    private readonly IMapper _mapper;
    private readonly ICaseRepository _caseRepository;
    private readonly IClientCaseRepository _clientCaseRepository;
    private readonly ICounterPartRepository _counterPartRepository;

    public CreateCaseCommandHandler(IMapper mapper,
        ICaseRepository caseRepository,
        IClientCaseRepository clientCaseRepository,
        ICounterPartRepository counterPartRepository)
    {
        _mapper = mapper;
        _caseRepository = caseRepository;
        _clientCaseRepository = clientCaseRepository;
        _counterPartRepository = counterPartRepository;
    }

    public async Task<CaseVm> Handle(CreateCaseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new CreateCaseCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var @case = _mapper.Map<Case>(request);

            @case = await _caseRepository.AddAsync(@case);

            request.Ids.ForEach(async id =>
            {
                var clientCase = new ClientCase
                {
                    CaseId = @case.Id,
                    ClientId = id
                };

                await _clientCaseRepository.AddAsync(clientCase);
            });

            return _mapper.Map<CaseVm>(@case);
        }
        catch (Exception ex)
        {
            var check1 = ex.InnerException;
            var check2 = ex.Message;
            throw;
        }

    }
}