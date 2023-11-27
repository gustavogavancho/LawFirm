using LawFirm.Application.Features.Cases.Models;
using MediatR;

namespace LawFirm.Application.Features.Cases.Queries.FindCase;

public class FindCasesQuery : IRequest<List<CaseVm>>
{
    public string SearchTerm { get; set; }
}