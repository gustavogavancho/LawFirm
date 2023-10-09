using MediatR;

namespace LawFirm.Application.Features.Cases.Commands.DeleteCase;

public class DeleteCaseCommand : IRequest
{
    public Guid ClientId { get; set; }
}