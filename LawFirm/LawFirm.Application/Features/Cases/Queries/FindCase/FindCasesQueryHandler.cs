using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Application.Features.Cases.Models;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Cases.Queries.FindCase;

public class FindCasesQueryHandler : IRequestHandler<FindCasesQuery, List<CaseVm>>
{
    private readonly IMapper _mapper;
    private readonly ICaseRepository _caseRepository;

    public FindCasesQueryHandler(IMapper mapper,
        ICaseRepository caseRepository)
    {
        _mapper = mapper;
        _caseRepository = caseRepository;
    }

    public async Task<List<CaseVm>> Handle(FindCasesQuery request, CancellationToken cancellationToken)
    {
        var cases = await _caseRepository.FindCaseBySearchTerm(request.SearchTerm);

        if (cases == null)
            throw new NotFoundException(nameof(Case), request.SearchTerm);

        var casesMapped = _mapper.Map<List<CaseVm>>(cases);

        return casesMapped;
    }
}