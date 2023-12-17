using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Application.Features.Events.Models;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventVm>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public CreateEventCommandHandler(IEventRepository eventRepository,
        IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<EventVm> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateEventCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        var @event = _mapper.Map<Event>(request);
        @event = await _eventRepository.AddAsync(@event);

        return _mapper.Map<EventVm>(@event);
    }
}