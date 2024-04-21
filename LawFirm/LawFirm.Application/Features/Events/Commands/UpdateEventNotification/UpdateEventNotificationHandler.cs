using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Events.Commands.UpdateEventNotification;

public class UpdateEventNotificationHandler : IRequestHandler<UpdateEventNotificationCommand>
{
    private readonly IEventRepository _eventRepository;

    public UpdateEventNotificationHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task Handle(UpdateEventNotificationCommand request, CancellationToken cancellationToken)
    {
        var eventToUpdate = await _eventRepository.GetByIdAsync(request.Id);

        if (eventToUpdate is null) throw new NotFoundException(nameof(Event), request.Id);

        eventToUpdate.IsNotified = true;

        await _eventRepository.UpdateAsync(eventToUpdate);
    }
}