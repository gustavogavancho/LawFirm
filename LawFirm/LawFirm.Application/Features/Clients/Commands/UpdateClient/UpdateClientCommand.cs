using MediatR;

namespace LawFirm.Application.Features.Clients.Commands.UpdateClient;

public class UpdateClientCommand : IRequest
{
    public Guid ClientId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public long Nit { get; set; }
    public string ClientType { get; set; }
    public string Representative { get; set; }
    public long PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
}