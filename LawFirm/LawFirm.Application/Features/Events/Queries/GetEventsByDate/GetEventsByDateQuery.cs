using LawFirm.Application.Features.Events.Models;
using LawFirm.Application.Models.Pagination;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.GetEventsByDate;

public class GetEventsByDateQuery : IRequest<List<EventVm>>
{
    public DateTime CurrentDate { get; set; }
}