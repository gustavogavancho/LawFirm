using LawFirm.Application.Features.Events.Commands.CreateEvent;
using LawFirm.Application.Features.Events.Commands.DeleteEvent;
using LawFirm.Application.Features.Events.Commands.UpdateEvent;
using LawFirm.Application.Features.Events.Models;
using LawFirm.Application.Features.Events.Queries.GetEventDetail;
using LawFirm.Application.Features.Events.Queries.GetEventList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LawFirm.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetEvents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<EventVm>>> GetEvents()
    {
        var response = await _mediator.Send(new GetEventListQuery());

        return Ok(response);
    }

    [HttpPost(Name = "CreateEvent")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EventVm))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<EventVm>> CreateEvent([FromBody] CreateEventCommand createEventCommand)
    {
        var entity = await _mediator.Send(createEventCommand);

        return CreatedAtAction(nameof(GetEvent), new { entity.Id }, entity);
    }

    [HttpGet("{id:guid}", Name = "GetEvent")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<EventVm>> GetEvent(Guid id)
    {
        var @event = new GetEventDetailQuery() { Id = id };
        return Ok(await _mediator.Send(@event));
    }

    [HttpPut(Name = "UpdateEvent")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateEvent([FromBody] UpdateEventCommand updateEventCommand)
    {
        await _mediator.Send(updateEventCommand);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteEvent")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteEvent(Guid id)
    {
        var deleteEventCommand = new DeleteEventCommand() { EventId = id };
        await _mediator.Send(deleteEventCommand);
        return NoContent();
    }
}