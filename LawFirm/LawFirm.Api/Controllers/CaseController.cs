using LawFirm.Application.Features.Cases.Commands.CreateCase;
using LawFirm.Application.Features.Cases.Commands.DeleteCase;
using LawFirm.Application.Features.Cases.Commands.UpdateCase;
using LawFirm.Application.Features.Cases.Models;
using LawFirm.Application.Features.Cases.Queries.FindCase;
using LawFirm.Application.Features.Cases.Queries.GetCaseDetail;
using LawFirm.Application.Features.Cases.Queries.GetCaseList;
using LawFirm.Application.Features.Cases.Queries.GetLatestCases;
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
public class CaseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetCases")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<PagingResponse<CaseVm>>> GetCases([FromQuery] ItemsParameters itemsParameters)
    {
        var dtos = await _mediator.Send(new GetPagedCaseListQuery() { ItemsParameters = itemsParameters });

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(dtos.MetaData));

        return Ok(new PagingResponse<CaseVm> { Items = dtos, MetaData = dtos.MetaData });
    }

    [AllowAnonymous]
    [HttpGet("getLatestCases", Name = "GetLatestsCases")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<CaseVm>>> GetLatestCases()
    {
        var dtos = await _mediator.Send(new GetLastestCasesQuery());

        return Ok(dtos);
    }

    [HttpPost(Name = "CreateCase")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CaseVm))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<CaseVm>> CreateCase([FromBody] CreateCaseCommand createCaseCommand)
    {
        var entity = await _mediator.Send(createCaseCommand);

        return CreatedAtAction(nameof(GetCase), new { entity.Id }, entity);
    }

    [HttpGet("{id:guid}", Name = "GetCase")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CaseVm>> GetCase(Guid id)
    {
        var entity = new GetCaseDetailQuery() { Id = id };
        return Ok(await _mediator.Send(entity));
    }

    [HttpGet("{searchTerm}", Name = "FindCasesBySearchTerm")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<CaseVm>>> FindCasesBySearchTerm(string searchTerm)
    {
        var client = new FindCasesQuery() { SearchTerm = searchTerm };
        return Ok(await _mediator.Send(client));
    }

    [HttpPut(Name = "UpdateCase")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateCase([FromBody] UpdateCaseCommand updateCaseCommand)
    {
        await _mediator.Send(updateCaseCommand);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteCase")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteCase(Guid id)
    {
        var deleteEventCommand = new DeleteCaseCommand() { ClientId = id };
        await _mediator.Send(deleteEventCommand);
        return NoContent();
    }
}