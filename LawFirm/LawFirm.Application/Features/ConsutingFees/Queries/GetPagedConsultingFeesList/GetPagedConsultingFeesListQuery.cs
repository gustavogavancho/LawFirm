using LawFirm.Application.Features.ConsutingFees.Models;
using LawFirm.Application.Models.Pagination;
using LawFirm.Domain.Pagination;
using MediatR;

namespace LawFirm.Application.Features.ConsutingFees.Queries.GetPagedConsultingFeesList;

public class GetPagedConsultingFeesListQuery : IRequest<PagedList<ConsultingFeeVM>>
{
    public ItemsParameters ItemsParameters { get; set; }
}