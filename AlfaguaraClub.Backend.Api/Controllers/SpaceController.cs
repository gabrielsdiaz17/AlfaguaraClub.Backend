using AlfaguaraClub.Backend.Application.Services.SpaceServices.CreateSpaceCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceServices.QuerySpaceCommands;
using AlfaguaraClub.Backend.Application.Services.SpaceServices.UpdateSpaceCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SpaceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name ="GetAllSpaces")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<SpaceListVm>>> GetAllSpaces()
        {
            var spaces = await _mediator.Send(new GetSpaceListQuery());
            return Ok(spaces);
        }
        [HttpGet("{id}", Name = "GetSpaceById")]
        public async Task<ActionResult<SpaceListVm>> GetSpaceById(long id)
        {
            var getSpaceQuery = new GetSpaceQuery() { SpaceId = id };
            return Ok(await _mediator.Send(getSpaceQuery));
        }

        [HttpPost(Name = "AddSpace"), Authorize]
        public async Task<ActionResult<CreateSpaceCommandResponse>> Create([FromBody] CreateSpaceCommand createSpaceCommand)
        {
            var response = await _mediator.Send(createSpaceCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateSpace"), Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateSpaceCommand updateSpaceCommand)
        {
            await _mediator.Send(updateSpaceCommand);
            return NoContent();
        }
    }
}
