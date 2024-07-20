using LawFirm.Application.Features.Cases.Models;
using LawFirm.Application.Features.Clients.Queries.GetPagedClientList;
using LawFirm.Application.Features.ConsutingFees.Models;
using LawFirm.Application.Features.ConsutingFees.Queries.GetPagedConsultingFeesList;
using LawFirm.Application.Models.Pagination;
using LawFirm.Domain.Pagination;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LawFirm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultingFeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultingFeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetConsultingFees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagingResponse<ConsultingFeeVM>>> GetConsultingFees([FromQuery] ItemsParameters itemsParameters)
        {
            var dtos = await _mediator.Send(new GetPagedConsultingFeesListQuery() { ItemsParameters = itemsParameters });

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(dtos.MetaData));

            return Ok(new PagingResponse<ConsultingFeeVM> { Items = dtos, MetaData = dtos.MetaData });
        }
    }
}
