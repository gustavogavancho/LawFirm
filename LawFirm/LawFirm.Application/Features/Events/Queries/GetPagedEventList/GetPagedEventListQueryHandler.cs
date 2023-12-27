using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Events.Models;
using LawFirm.Application.Models.Pagination;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.GetPagedEventList;

public class GetPagedEventListQueryHandler : IRequestHandler<GetPagedEventListQuery, PagedList<EventVm>>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _eventRepository;

    public GetPagedEventListQueryHandler(IMapper mapper, IEventRepository eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }

    public async Task<PagedList<EventVm>> Handle(GetPagedEventListQuery request, CancellationToken cancellationToken)
    {
        var pagedItems = (await _eventRepository.ListAllAsync(true)).OrderByDescending(x => x.EventStartDate);

        var mappedItems = _mapper.Map<List<EventVm>>(pagedItems);

        return PagedList<EventVm>.ToPagedList(mappedItems, request.ItemsParameters.PageNumber, request.ItemsParameters.PageSize);
    }
}