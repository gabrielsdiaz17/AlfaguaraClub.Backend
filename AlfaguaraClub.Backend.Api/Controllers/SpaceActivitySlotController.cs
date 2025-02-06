using AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.SpaceActivitySlotsCommands.CreateSlotCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.SpaceActivitySlotsCommands.QuerySlotCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.SpaceActivitySlotsCommands.UpdateSlotCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceActivitySlotServices.CreateSlotsCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceActivitySlotController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SpaceActivitySlotController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/GetSpaceActivitySlotBySpaceActivityId/{id}", Name = "GetSpaceActivitySlotBySpaceActivityId"), Authorize]
        public async Task<ActionResult<SpaceActivitySlotVm>> GetSpaceActivitySlotBySpaceActivityId(long id)
        {
            var slotActivity = new QuerySpaceActivitySlotCommand() { SpaceActivityId = id };
            return await _mediator.Send(slotActivity);
        }
        [HttpPost(Name ="AddSpaceActivitySlot"), Authorize]
        public async Task<ActionResult<CreateSpaceActivitySlotCommandResponse>> AddSpaceActivitySlot([FromBody] CreateSpaceActivitySlotCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut(Name = "UpdateSpaceActivitySlot"), Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateSpaceActivitySlot([FromBody] UpdateSlotForSwimmingPool request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

    }
}
