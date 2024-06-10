using AlfaguaraClub.Backend.Application.Services.BillingServices.CreateBillingCommands;
using AlfaguaraClub.Backend.Application.Services.BillingServices.QueryBillingCommands;
using AlfaguaraClub.Backend.Application.Services.BillingServices.UpdateBillingCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BillingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllBillings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<BillingListVm>>> GetAllBillings()
        {
            var billings = await _mediator.Send(new GetBillingListQuery());
            return Ok(billings);
        }

        [HttpGet("/GetBillingById/{id}", Name = "GetBillingById")]
        public async Task<ActionResult<BillingListVm>> GetBillingById(long id)
        {
            var getBillingQuery= new GetBillingQuery() { BillingId = id};
            return Ok(await _mediator.Send(getBillingQuery));
        }

        [HttpGet("/GetBillingByDate/{date}", Name = "GetBillingByDate")]
        public async Task<ActionResult<List<BillingListVm>>> GetBillingByDate(DateTimeOffset date)
        {
            var getBillingListQueryDate = new GetBillingListDateByDate() { Date = date };
            return Ok(await _mediator.Send(getBillingListQueryDate));
        }

        [HttpGet("/GetBillingByStatus/{status}", Name = "GetBillingByStatus")]
        public async Task<ActionResult<List<BillingListVm>>> GetBillingByStatus(int status)
        {
            var getBillingListStatus = new GetBillingListByStatus() { BillingStatusId = status};
            return Ok(await _mediator.Send(getBillingListStatus));
        }

        [HttpPost(Name = "GetBillingByDateAndStatus")]
        public async Task<ActionResult<CreateBillingCommandResponse>> GetBillingByDateAndStatus([FromBody] GetBillingListByDateAndStatus getBillingListDS)
        {
            var response = await _mediator.Send(getBillingListDS);
            return Ok(response);
        }

        [HttpPost(Name = "AddBilling")]
        public async Task<ActionResult<CreateBillingCommandResponse>> Create([FromBody] CreateBillingCommand createBillingCommand)
        {
            var response = await _mediator.Send(createBillingCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateBilling")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBillingCommand updateBillingCommand)
        {
            await _mediator.Send(updateBillingCommand);
            return NoContent();
        }
    }
}
