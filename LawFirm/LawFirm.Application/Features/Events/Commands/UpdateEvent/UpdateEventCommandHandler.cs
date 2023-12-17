using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _eventRepository;

    public UpdateEventCommandHandler(IMapper mapper,
        IEventRepository eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }

    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateEventCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        var eventToUpdate = await _eventRepository.GetByIdAsync(request.Id);

        if (eventToUpdate is null) throw new NotFoundException(nameof(Event), request.Id);

        _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

        await _eventRepository.UpdateAsync(eventToUpdate);
    }
}