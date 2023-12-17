using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
{
    private readonly IEventRepository _eventRepository;

    public DeleteEventCommandHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);

        if (eventToDelete == null)
        {
            throw new NotFoundException(nameof(Event), request.EventId);
        }

        await _eventRepository.DeleteAsync(eventToDelete);
    }
}