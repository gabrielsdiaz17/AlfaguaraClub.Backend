using AlfaguaraClub.Backend.Application.Services.StatusBookingServices.CreateStatusBookingCommands;
using AlfaguaraClub.Backend.Application.Services.StatusBookingServices.QueryStatusBookingCommands;
using AlfaguaraClub.Backend.Application.Services.StatusBookingServices.UpdateStatusBookingCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusBookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StatusBookingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetStatusBooking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<StatusBookingListVm>>> GetStatusBooking()
        {
            var statusBooking = await _mediator.Send(new GetStatusBookingListQuery());
            return Ok(statusBooking);
        }
        [HttpPost(Name = "AddStatusBooking")]
        public async Task<ActionResult<CreateStatusBookingCommandResponse>> Create([FromBody] CreateStatusBookingCommand createStatusBookingCommand)
        {
            var response = await _mediator.Send(createStatusBookingCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateStatusBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateStatusBookingCommand updateStatusBookingCommand)
        {
            await _mediator.Send(updateStatusBookingCommand);
            return NoContent();
        }
    }
}
