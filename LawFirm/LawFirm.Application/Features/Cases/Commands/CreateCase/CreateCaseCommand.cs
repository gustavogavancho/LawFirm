using LawFirm.Application.Features.Cases.Models;
using MediatR;

namespace LawFirm.Application.Features.Cases.Commands.CreateCase;

public class CreateCaseCommand : IRequest<CaseVm>
{
    public List<Guid> Ids { get; set; }
    public string FileNumber { get; set; }
}