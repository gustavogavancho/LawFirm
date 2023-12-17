using LawFirm.Application.Features.Events.Models;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.GetEventDetail;

public class GetEventDetailQuery : IRequest<EventVm>
{
    public Guid Id { get; set; }
}