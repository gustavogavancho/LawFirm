﻿using MediatR;

namespace LawFirm.Application.Features.Clients.Commands.CreateClient;

public record CreateClientCommand : IRequest<CreateClientCommandResponse>
{
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public long Nit { get; set; }
    public string ClientType { get; set; } = default!;
    public long PhoneNumber { get; set; }
    public string Address { get; set; } = default!;
    public string Email { get; set; } = default!;
}