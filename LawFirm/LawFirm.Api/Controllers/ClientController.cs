using LawFirm.Application.Features.Clients.Commands.CreateClient;
using LawFirm.Application.Features.Clients.Commands.DeleteClient;
using LawFirm.Application.Features.Clients.Commands.UpdateClient;
using LawFirm.Application.Features.Clients.Models;
using LawFirm.Application.Features.Clients.Queries.GetClientDetail;
using LawFirm.Application.Features.Clients.Queries.GetPagedClientList;
using LawFirm.Application.Models.Pagination;
using LawFirm.Domain.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

    [HttpGet(Name = "GetClients")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<PagingResponse<ClientVm>>> GetClients([FromQuery] ItemsParameters itemsParameters)
    {
        var dtos = await _mediator.Send(new GetPagedClientListQuery() { ItemsParameters = itemsParameters });

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(dtos.MetaData));

        return Ok(new PagingResponse<ClientVm> { Items = dtos, MetaData = dtos.MetaData});
    }

    [HttpPost(Name = "CreateClient")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ClientVm))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<ClientVm>> CreateClient([FromBody] CreateClientCommand createClientCommand)
    {
        var entity = await _mediator.Send(createClientCommand);

        return CreatedAtAction(nameof(GetClient), new { entity.Id }, entity);
    }

    [HttpGet("{id:guid}", Name = "GetClient")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ClientVm>> GetClient(Guid id)
    {
        var client = new GetClientDetailQuery() { Id = id };
        return Ok(await _mediator.Send(client));
    }

    [HttpGet("{searchTerm}", Name = "FindClientsBySearchTerm")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ClientVm>>> FindClientsBySearchTerm(string searchTerm)
    {
        var client = new FindClientsQuery() { SearchTerm = searchTerm };
        return Ok(await _mediator.Send(client));
    }

    [HttpPut(Name = "UpdateClient")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateClient([FromBody] UpdateClientCommand updateClientCommand)
    {
        await _mediator.Send(updateClientCommand);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteClient")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteClient(Guid id)
    {
        var deleteEventCommand = new DeleteClientCommand() { ClientId = id };
        await _mediator.Send(deleteEventCommand);
        return NoContent();
    }
}