using LawFirm.Application.Features.Cases.Models;
using LawFirm.Application.Models.Pagination;
using LawFirm.Domain.Pagination;
using MediatR;

namespace LawFirm.Application.Features.Cases.Queries.GetCaseList;

public class GetPagedCaseListQuery : IRequest<PagedList<CaseVm>>
{
    public ItemsParameters ItemsParameters { get; set; }
}