using AlfaguaraClub.Backend.Application.Services.TennisFieldActivityServices.CreateTennisFieldActivityCommands;
using AlfaguaraClub.Backend.Application.Services.TennisFieldActivityServices.QueryTennisFieldActivityCommands;
using AlfaguaraClub.Backend.Application.Services.TennisFieldActivityServices.UpdateTennisFieldActivityCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TennisFieldSlotController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TennisFieldSlotController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = "AddTennisFieldActivitySlot"), Authorize]
        public async Task<ActionResult<CreateTennisFieldActivityCommandResponse>> AddTennisFieldActivitySlot([FromBody] CreateTennisFieldActivityCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("GetTennisFieldSlotBySpaceActivityId/{id}", Name = "GetTennisFieldSlotBySpaceActivityId"), Authorize]
        public async Task<ActionResult<List<TennisFieldActivitySlotVm>>> GetTennisFieldSlotBySpaceActivityId(long id)
        {
            var slotTennisField = new QueryTennisFieldActivityCommand() { SpaceActivityId = id };
            return await _mediator.Send(slotTennisField);
        }
        [HttpPut(Name = "UpdateTennisFieldActivitySlot"), Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateTennisFieldActivitySlot([FromBody] UpdateSlotForTennisCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
