using LawFirm.Application.Features.Cases.Models;
using MediatR;

namespace LawFirm.Application.Features.Cases.Queries.GetCaseDetail;

public class GetCaseDetailQuery : IRequest<CaseVm>
{
    public Guid Id { get; set; }
}