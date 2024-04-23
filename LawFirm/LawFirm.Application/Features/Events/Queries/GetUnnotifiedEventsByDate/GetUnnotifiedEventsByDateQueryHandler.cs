using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Events.Models;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.GetUnnotifiedEventsByDate;

public class GetUnnotifiedEventsByDateQueryHandler : IRequestHandler<GetUnnotifiedEventsByDateQuery, List<EventVm>>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _eventRepository;

    public GetUnnotifiedEventsByDateQueryHandler(IMapper mapper, IEventRepository eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }

    public async Task<List<EventVm>> Handle(GetUnnotifiedEventsByDateQuery request, CancellationToken cancellationToken)
    {
        var pagedItems = (await _eventRepository.FindUnnotifiedEventsByStartDate(request.CurrentDate)).OrderByDescending(x => x.EventStartDate);

        var mappedItems = _mapper.Map<List<EventVm>>(pagedItems);

        return mappedItems;
    }
}