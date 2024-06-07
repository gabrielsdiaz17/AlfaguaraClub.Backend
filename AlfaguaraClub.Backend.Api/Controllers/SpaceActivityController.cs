using AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.CreateSpaceActivityCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.QuerySpaceActivityCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.UpdateSpaceActivityCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceServices.CreateSpaceCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceServices.UpdateSpaceCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceActivityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SpaceActivityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet(Name = "GetAllSpacesActivities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<SpaceActivityListVm>>> GetAllSpacesActivities()
        {
            var spaceActivities = await _mediator.Send(new GetSpaceActivityListQuery());
            return Ok(spaceActivities);
        }
       
        [HttpGet("{id}", Name = "GetSpaceActivityById")]
        public async Task<ActionResult<SpaceActivityListVm>> GetSpaceActivityById(long id)
        {
            var getSpaceActivity = new GetSpaceActivityQuery() { SpaceActivityId = id };
            return Ok(await _mediator.Send(getSpaceActivity));
        }
        
        [HttpGet("{spaceId}", Name = "GetSpaceActivityBySpaceId")]
        public async Task<ActionResult<SpaceActivityListVm>> GetSpaceActivityBySpaceId(long spaceId)
        {
            var getSpaceActivityBySpace = new GetSpaceActivityBySpaceQuery() { SpaceId = spaceId };
            return Ok(await _mediator.Send(getSpaceActivityBySpace));
        }

        [HttpPost(Name = "AddSpaceActivity")]
        public async Task<ActionResult<CreateSpaceActivityCommandResponse>> Create([FromBody] CreateSpaceActivityCommand createSpaceActivityCommand)
        {
            var response = await _mediator.Send(createSpaceActivityCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateSpaceActivity")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateSpaceActivityCommand updateSpaceActivityCommand)
        {
            await _mediator.Send(updateSpaceActivityCommand);
            return NoContent();
        }
    }
}
