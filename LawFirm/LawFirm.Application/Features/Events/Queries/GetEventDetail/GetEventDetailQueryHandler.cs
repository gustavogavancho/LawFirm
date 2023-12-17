using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Application.Features.Events.Models;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.GetEventDetail;

public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventVm>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _eventRepository;

    public GetEventDetailQueryHandler(IMapper mapper,
        IEventRepository eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }

    public async Task<EventVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByIdAsync(request.Id);

        if (@event == null)
        {
            throw new NotFoundException(nameof(Event), request.Id);
        }

        var eventDto = _mapper.Map<EventVm>(@event);

        return eventDto;
    }
}