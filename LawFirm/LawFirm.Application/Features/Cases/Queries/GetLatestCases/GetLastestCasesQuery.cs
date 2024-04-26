using LawFirm.Application.Features.Cases.Models;
using MediatR;

namespace LawFirm.Application.Features.Cases.Queries.GetLatestCases;

public class GetLastestCasesQuery : IRequest<List<CaseVm>>
{
}