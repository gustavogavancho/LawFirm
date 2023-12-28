using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Application.Features.Events.Models;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.FindEvent;

public class FindEventsQueryHandler : IRequestHandler<FindEventsQuery, List<EventVm>>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _eventRepository;

    public FindEventsQueryHandler(IMapper mapper, IEventRepository eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }

    public async Task<List<EventVm>> Handle(FindEventsQuery request, CancellationToken cancellationToken)
    {
        var events = await _eventRepository.FindEventBySearchTerm(request.SearchTerm);

        if (events == null)
            throw new NotFoundException(nameof(Event), request.SearchTerm);

        var eventsDto = _mapper.Map<List<EventVm>>(events);

        return eventsDto;
    }
}