using AlfaguaraClub.Backend.Application.Services.TypeActivityServices.CreateTypeActivityCommands;
using AlfaguaraClub.Backend.Application.Services.TypeActivityServices.QueryTypeActivityCommands;
using AlfaguaraClub.Backend.Application.Services.TypeActivityServices.UpdateTypeActivityCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeActivityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TypeActivityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetTypeActivities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<TypeActivityListVm>>> GetTypeActivities()
        {
            var typeActivities = await _mediator.Send(new GetTypeActivityListQuery());
            return Ok(typeActivities);
        }
        [HttpPost(Name = "AddTypeActivity")]
        public async Task<ActionResult<CreateTypeActivityCommandResponse>> Create([FromBody] CreateTypeActivityCommand createTypeActivityCommand)
        {
            var newTypeActivity = await _mediator.Send(createTypeActivityCommand);
            return Ok(newTypeActivity);
        }
        [HttpPut(Name = "UpdateTypeActivity")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateTypeActivityCommand updateTypeActivityCommand)
        {
            await _mediator.Send(updateTypeActivityCommand);
            return NoContent();
        }
    }
}
