using LawFirm.Application.Features.Events.Models;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.GetEventsByStartDate;

public class GetEventsByStartDateQuery : IRequest<List<EventVm>>
{
    public DateTime Date { get; set; }
}