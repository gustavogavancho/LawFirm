using LawFirm.Application.Features.Events.Commands.CreateEvent;
using LawFirm.Application.Features.Events.Commands.DeleteEvent;
using LawFirm.Application.Features.Events.Commands.UpdateEvent;
using LawFirm.Application.Features.Events.Models;
using LawFirm.Application.Features.Events.Queries.FindEvent;
using LawFirm.Application.Features.Events.Queries.GetEventDetail;
using LawFirm.Application.Features.Events.Queries.GetEventList;
using LawFirm.Application.Features.Events.Queries.GetPagedEventList;
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
public class EventController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet(Name = "GetEvents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<EventVm>>> GetEvents()
    {
        var response = await _mediator.Send(new GetEventListQuery());

        return Ok(response);
    }

    [HttpGet("paged", Name = "GetPagedEvents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<PagingResponse<EventVm>>> GetPagedEvents([FromQuery] ItemsParameters itemsParameters)
    {
        var response = await _mediator.Send(new GetPagedEventListQuery() { ItemsParameters = itemsParameters });

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(response.MetaData));

        return Ok(new PagingResponse<EventVm> { Items = response, MetaData = response.MetaData });
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

    [HttpGet("{searchTerm}", Name = "FindEventsBySearchTerm")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<EventVm>>> FindEventsBySearchTerm(string searchTerm)
    {
        var events = new FindEventsQuery() { SearchTerm = searchTerm };
        return Ok(await _mediator.Send(events));
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