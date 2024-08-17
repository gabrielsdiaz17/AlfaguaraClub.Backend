using AlfaguaraClub.Backend.Application.Services.BillingDetailServices.CreateBillingDetailCommands;
using AlfaguaraClub.Backend.Application.Services.BillingDetailServices.QueryBillingDetailCommands;
using AlfaguaraClub.Backend.Application.Services.BillingDetailServices.UpdateBillingDetailCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BillingDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetBillingDetails"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<BillingDetailListVm>>> GetBillingDetails(long billingId)
        {
            var billingDetails = new GetBillingDetailListQuery() { BillingId = billingId };
            return Ok(await _mediator.Send(billingDetails));
        }

        [HttpPost(Name = "AddBillingDetail"), Authorize]
        public async Task<ActionResult<CreateBillingDetailCommandResponse>> Create([FromBody] CreateBillingDetailCommand createBillingDetailCommand)
        {
            var response = await _mediator.Send(createBillingDetailCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateBillingDetail")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBillingDetailCommand updateBillingDetailCommand)
        {
            await _mediator.Send(updateBillingDetailCommand);
            return NoContent();
        }
    }
}
