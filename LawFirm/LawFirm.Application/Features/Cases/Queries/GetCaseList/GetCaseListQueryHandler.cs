using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Cases.Models;
using MediatR;

namespace LawFirm.Application.Features.Cases.Queries.GetCaseList;

public class GetCaseListQueryHandler : IRequestHandler<GetCaseListQuery, List<CaseVm>>
{
    private readonly IMapper _mapper;
    private readonly ICaseRepository _caseRepository;

    public GetCaseListQueryHandler(IMapper mapper,
        ICaseRepository caseRepository)
    {
        _mapper = mapper;
        _caseRepository = caseRepository;
    }

    public async Task<List<CaseVm>> Handle(GetCaseListQuery request, CancellationToken cancellationToken)
    {
        var cases = await _caseRepository.GetCasesWithRelatedEntities();

        return _mapper.Map<List<CaseVm>>(cases);
    }
}