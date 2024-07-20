using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.ConsutingFees.Models;
using LawFirm.Application.Models.Pagination;
using MediatR;

namespace LawFirm.Application.Features.ConsutingFees.Queries.GetPagedConsultingFeesList;

public class GetPagedConsultingFeesListQueryHandler : IRequestHandler<GetPagedConsultingFeesListQuery, PagedList<ConsultingFeeVM>>
{
    private readonly IMapper _mapper;
    private readonly IConsultingFeeRepository _consultingFeeRepository;

    public GetPagedConsultingFeesListQueryHandler(IMapper mapper, IConsultingFeeRepository consultingFeeRepository)
    {
        _mapper = mapper;
        _consultingFeeRepository = consultingFeeRepository;
    }

    public async Task<PagedList<ConsultingFeeVM>> Handle(GetPagedConsultingFeesListQuery request, CancellationToken cancellationToken)
    {
        var pagedItems = (await _consultingFeeRepository.ListAllAsync(true)).OrderByDescending(x => x.ExpirationDate);

        var mappedItems = _mapper.Map<List<ConsultingFeeVM>>(pagedItems);

        return PagedList<ConsultingFeeVM>.ToPagedList(mappedItems, request.ItemsParameters.PageNumber, request.ItemsParameters.PageSize);

        throw new NotImplementedException();
    }
}