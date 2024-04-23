using LawFirm.Application.Features.Events.Models;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.GetUnnotifiedEventsByDate;

public class GetUnnotifiedEventsByDateQuery : IRequest<List<EventVm>>
{
    public DateTime CurrentDate { get; set; }
}