using LawFirm.Application.Features.Events.Models;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.FindEvent;

public class FindEventsQuery : IRequest<List<EventVm>>
{
    public string SearchTerm { get; set; }
}