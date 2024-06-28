using AlfaguaraClub.Backend.Application.Services.BillingStatusServices.CreateBillingStatusCommands;
using AlfaguaraClub.Backend.Application.Services.BillingStatusServices.QueryBillingStatusCommands;
using AlfaguaraClub.Backend.Application.Services.BillingStatusServices.UpdateBillingStatusCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingStatusController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BillingStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetBillingStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<BillingStatusListVm>>> GetBillingStatus()
        {
            var listBillingStatus = new GetBillingStatusListQuery();
            return Ok(await _mediator.Send(listBillingStatus));
        }
        [HttpPost(Name = "AddBillingStatus")]
        public async Task<ActionResult<CreateBillingStatusCommandResponse>> Create([FromBody] CreateBillingStatusCommand createBillingStatusCommand)
        {
            var response = await _mediator.Send(createBillingStatusCommand);
            return Ok(response);
        }
        [HttpPut(Name = "UpdateBillingStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBillingStatusCommand updateBillingStatusCommand)
        {
            await _mediator.Send(updateBillingStatusCommand);
            return NoContent();
        }

    }
}
