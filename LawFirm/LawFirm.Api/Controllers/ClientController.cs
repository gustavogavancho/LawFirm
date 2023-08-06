using LawFirm.Application.Features.Clients.Commands.CreateClient;
using LawFirm.Application.Features.Clients.Commands.DeleteClient;
using LawFirm.Application.Features.Clients.Commands.UpdateClient;
using LawFirm.Application.Features.Clients.Queries.GetClientDetail;
using LawFirm.Application.Features.Clients.Queries.GetClientList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LawFirm.Api.Controllers;

[Authorize]
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
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ClientListVm>>> GetAllClients()
    {
        var dtos = await _mediator.Send(new GetClientListQuery());
        return Ok(dtos);
    }

    [HttpPost(Name = "AddEvent")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateClientDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<CreateClientDto>> Create([FromBody] CreateClientCommand createClientCommand)
    {
        var entity = await _mediator.Send(createClientCommand);

        return CreatedAtAction(nameof(GetClientById), new { entity.Id }, entity);
    }

    [HttpGet("{id}", Name = "GetClientById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ClientDetailVm>> GetClientById(Guid id)
    {
        var getEventDetailQuery = new GetClientDetailQuery() { Id = id };
        return Ok(await _mediator.Send(getEventDetailQuery));
    }

    [HttpPut(Name = "UpdateClient")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateClientCommand updateClientCommand)
    {
        await _mediator.Send(updateClientCommand);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteClient")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var deleteEventCommand = new DeleteClientCommand() { ClientId = id };
        await _mediator.Send(deleteEventCommand);
        return NoContent();
    }
}