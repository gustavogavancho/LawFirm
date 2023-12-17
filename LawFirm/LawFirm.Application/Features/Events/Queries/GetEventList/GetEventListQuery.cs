using LawFirm.Application.Features.Events.Models;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.GetEventList;

public class GetEventListQuery : IRequest<List<EventVm>>
{
}