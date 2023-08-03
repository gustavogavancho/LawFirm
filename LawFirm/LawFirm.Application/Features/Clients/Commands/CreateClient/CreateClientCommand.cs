using MediatR;

namespace LawFirm.Application.Features.Clients.Commands.CreateClient;

public record CreateClientCommand : IRequest<CreateClientDto>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public long Nit { get; set; }
    public string ClientType { get; set; }
    public long PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
}