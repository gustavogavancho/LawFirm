using LawFirm.Application.Features.Clients.Models;
using LawFirm.Application.Models.Pagination;
using LawFirm.Domain.Pagination;
using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetPagedClientList;

public class GetPagedClientListQuery : IRequest<PagedList<ClientVm>>
{
    public ItemsParameters ItemsParameters { get; set; }
}