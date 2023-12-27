using LawFirm.Application.Features.Events.Models;
using LawFirm.Application.Models.Pagination;
using LawFirm.Domain.Pagination;
using MediatR;

namespace LawFirm.Application.Features.Events.Queries.GetPagedEventList;

public class GetPagedEventListQuery : IRequest<PagedList<EventVm>>
{
    public ItemsParameters ItemsParameters { get; set; }
}