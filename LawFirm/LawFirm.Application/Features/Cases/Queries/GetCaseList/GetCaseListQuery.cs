using LawFirm.Application.Features.Cases.Models;
using MediatR;

namespace LawFirm.Application.Features.Cases.Queries.GetCaseList;

public class GetCaseListQuery : IRequest<List<CaseVm>>
{
}