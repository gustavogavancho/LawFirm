using MediatR;

namespace LawFirm.Application.Features.Clients.Commands.DeleteClient;

public class DeleteClientCommand : IRequest
{
    public Guid ClientId { get; set; }
}