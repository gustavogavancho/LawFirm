using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Events.Models;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.GetEventList;

public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<EventVm>>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _eventRepository;

    public GetEventListQueryHandler(IMapper mapper,
        IEventRepository eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }

    public async Task<List<EventVm>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
    {
        var events = (await _eventRepository.ListAllAsync(true));

        return _mapper.Map<List<EventVm>>(events);
    }
}