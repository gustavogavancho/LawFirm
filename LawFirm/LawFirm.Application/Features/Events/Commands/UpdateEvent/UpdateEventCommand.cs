using MediatR;

namespace LawFirm.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommand : IRequest
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime EventStartDate { get; set; }
    public DateTime EventEndDate { get; set; }
    public Guid CaseId { get; set; }
}