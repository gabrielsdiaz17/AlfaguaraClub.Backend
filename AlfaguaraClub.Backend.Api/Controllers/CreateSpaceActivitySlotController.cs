using AlfaguaraClub.Backend.Application.Services.SpaceActivitySlotServices.CreateSlotsCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateSpaceActivitySlotController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CreateSpaceActivitySlotController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = "AddSpaceActivitySlot"), Authorize]
        public async Task<ActionResult<CreateSpaceActivitySlotCommandResponse>> Create([FromBody] CreateSpaceActivitySlotCommand command)
        {
            var newSpaceActivitySlot = await _mediator.Send(command);
            return Ok(newSpaceActivitySlot);
        }
    }
}
