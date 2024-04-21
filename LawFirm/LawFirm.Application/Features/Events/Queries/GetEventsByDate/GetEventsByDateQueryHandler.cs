using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Events.Models;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.GetEventsByDate;

public class GetEventsByDateQueryHandler : IRequestHandler<GetEventsByDateQuery, List<EventVm>>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _eventRepository;

    public GetEventsByDateQueryHandler(IMapper mapper, IEventRepository eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }

    public async Task<List<EventVm>> Handle(GetEventsByDateQuery request, CancellationToken cancellationToken)
    {
        var pagedItems = (await _eventRepository.FindEventsByStartDate(request.CurrentDate)).OrderByDescending(x => x.EventStartDate);

        var mappedItems = _mapper.Map<List<EventVm>>(pagedItems);

        return mappedItems;
    }
}