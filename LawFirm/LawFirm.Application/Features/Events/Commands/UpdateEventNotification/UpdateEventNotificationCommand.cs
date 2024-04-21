using MediatR;

namespace LawFirm.Application.Features.Events.Commands.UpdateEventNotification;

public class UpdateEventNotificationCommand : IRequest
{
    public Guid Id { get; set; }
}