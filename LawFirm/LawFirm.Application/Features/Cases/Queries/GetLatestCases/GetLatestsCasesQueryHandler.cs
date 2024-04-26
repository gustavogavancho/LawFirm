using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Cases.Models;
using MediatR;

namespace LawFirm.Application.Features.Cases.Queries.GetLatestCases;

public class GetLatestsCasesQueryHandler : IRequestHandler<GetLastestCasesQuery, List<CaseVm>>
{
    private readonly IMapper _mapper;
    private readonly ICaseRepository _caseRepository;

    public GetLatestsCasesQueryHandler(IMapper mapper,
        ICaseRepository caseRepository)
    {
        _mapper = mapper;
        _caseRepository = caseRepository;
    }

    public async Task<List<CaseVm>> Handle(GetLastestCasesQuery request, CancellationToken cancellationToken)
    {
        var cases = await _caseRepository.GetLatestCases();

        var casesMapped = _mapper.Map<List<CaseVm>>(cases);

        return casesMapped;
    }
}
