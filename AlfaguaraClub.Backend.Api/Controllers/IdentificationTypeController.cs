using AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.CreateIdentificationTypeCommands;
using AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.QueryIdentificationTypeCommands;
using AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.UpdateIdentificationTypeCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificationTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IdentificationTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetIdentificationTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<IdentificationTypeListVm>>> GetIdentificationTypes()
        {
            var identificationTypes = await _mediator.Send(new QueryIdentificationTypeQuery());
            return Ok(identificationTypes);
        }
        [HttpPost(Name = "AddIdentificationType"), Authorize]
        public async Task<ActionResult<CreateIdentificationTypeCommandResponse>> Create([FromBody] CreateIdentificationTypeCommand createIdentificationTypeCommand)
        {
            var response = await _mediator.Send(createIdentificationTypeCommand);
            return Ok(response);
        }
        [HttpPut(Name = "UpdateIdentificationType"), Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UpdateIdentificationTypeCommand>> Update([FromBody] UpdateIdentificationTypeCommand updateIdentificationTypeCommand)
        {
            await _mediator.Send(updateIdentificationTypeCommand);
            return NoContent();
        }
    }
}
