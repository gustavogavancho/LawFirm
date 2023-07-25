using LawFirm.Application.Features.Clients.Commands.CreateClient;
using LawFirm.Application.Features.Clients.Queries.GetClientList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LawFirm.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllClients")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ClientListVm>>> GetAllClients()
    {
        var dtos = await _mediator.Send(new GetClientListQuery());
        return Ok(dtos);
    }

    [HttpPost(Name = "AddEvent")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateClientCommand createClientCommand)
    {
        var id = await _mediator.Send(createClientCommand);
        return Ok(id);
    }
}