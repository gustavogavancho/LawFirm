using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Events.Models;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.GetEventsByStartDate;

public class GetEventsByStartDateQueryHandler : IRequestHandler<GetEventsByStartDateQuery, List<EventVm>>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _eventRepository;

    public GetEventsByStartDateQueryHandler(IMapper mapper, IEventRepository eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }

    public async Task<List<EventVm>> Handle(GetEventsByStartDateQuery request, CancellationToken cancellationToken)
    {
        var events = await _eventRepository.FindEventsByDate(request.Date);

        var mappedItems = _mapper.Map<List<EventVm>>(events);

        return mappedItems;
    }
}