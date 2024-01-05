using LawFirm.Application.Features.Events.Models;
using MediatR;

namespace LawFirm.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommand : IRequest<EventVm>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime EventStartDate { get; set; }
    public DateTime EventEndDate { get; set; }
    public Guid CaseId { get; set; }
}