using LawFirm.Application.Responses;

namespace LawFirm.Application.Features.Clients.Commands.CreateClient;

public class CreateClientCommandResponse : BaseResponse
{
    public CreateClientCommandResponse() : base()
    {
        
    }

    public CreateClientDto Client { get; set; } = default!;
}