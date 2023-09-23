using MediatR;

namespace LawFirm.Application.Features.Cases.Commands.CreateCase;

public class CreateCaseCommand : IRequest
{
    public string FileNumber { get; set; }
}