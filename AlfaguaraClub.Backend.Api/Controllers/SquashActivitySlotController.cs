using AlfaguaraClub.Backend.Application.Services.SquashFieldActivityServices.CreateSquashFieldActivityCommands;
using AlfaguaraClub.Backend.Application.Services.SquashFieldActivityServices.QuerySquashFieldActivityCommands;
using AlfaguaraClub.Backend.Application.Services.SquashFieldActivityServices.UpdateSquashFieldActivityCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquashActivitySlotController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SquashActivitySlotController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = "AddSquashActivitySlot"), Authorize]
        public async Task <ActionResult<CreateSquashFieldActivityCommandResponse>> AddSquashActivitySlot([FromBody] CreateSquashFieldActivityCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("GetSquashActivitySlotBySpaceActivityId/{id}", Name = "GetSquashActivitySlotBySpaceActivityId"), Authorize]
        public async Task<ActionResult<List<SquashFieldActivitySlotVm>>> GetSquashActivitySlotBySpaceActivityId(long id)
        {
            var squashActivity = new QuerySquashFieldActivityCommand() { SpaceActivityId = id };
            return await _mediator.Send(squashActivity);
        }
        [HttpPut(Name ="UpdateSquashFieldActivitySlot"), Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task <ActionResult> UpdateSquashFieldActivitySlot([FromBody] UpdateSlotForSquashFieldCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
