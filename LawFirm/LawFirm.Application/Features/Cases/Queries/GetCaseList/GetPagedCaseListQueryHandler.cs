using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Cases.Models;
using LawFirm.Application.Models.Pagination;
using MediatR;

namespace LawFirm.Application.Features.Cases.Queries.GetCaseList;

public class GetPagedCaseListQueryHandler : IRequestHandler<GetPagedCaseListQuery, PagedList<CaseVm>>
{
    private readonly IMapper _mapper;
    private readonly ICaseRepository _caseRepository;

    public GetPagedCaseListQueryHandler(IMapper mapper,
        ICaseRepository caseRepository)
    {
        _mapper = mapper;
        _caseRepository = caseRepository;
    }

    public async Task<PagedList<CaseVm>> Handle(GetPagedCaseListQuery request, CancellationToken cancellationToken)
    {
        var cases = await _caseRepository.ListAllAsync(true, x => x.Clients, x=> x.CounterParts);

        var mappedItems =  _mapper.Map<List<CaseVm>>(cases.OrderByDescending(x => x.CreatedDate));

        return PagedList<CaseVm>.ToPagedList(mappedItems, request.ItemsParameters.PageNumber, request.ItemsParameters.PageSize);
    }
}