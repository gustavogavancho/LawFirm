using LawFirm.Application.Features.Cases.Commands.CreateCase;
using LawFirm.Application.Features.Cases.Models;
using LawFirm.Application.Features.Cases.Queries.GetCaseDetail;
using LawFirm.Application.Features.Cases.Queries.GetCaseList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LawFirm.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CaseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "CreateCase")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CaseVm))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<CaseVm>> CreateClient([FromBody] CreateCaseCommand createCaseCommand)
    {
        var entity = await _mediator.Send(createCaseCommand);

        return CreatedAtAction(nameof(GetCase), new { entity.Id }, entity);
    }

    [HttpGet(Name = "GetCases")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<CaseVm>>> GetClients()
    {
        var dtos = await _mediator.Send(new GetCaseListQuery());

        return Ok(dtos);
    }

    [HttpGet("{id:guid}", Name = "GetCase")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CaseVm>> GetCase(Guid id)
    {
        var entity = new GetCaseDetailQuery() { Id = id };
        return Ok(await _mediator.Send(entity));
    }
}