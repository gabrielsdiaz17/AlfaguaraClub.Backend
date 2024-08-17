using AlfaguaraClub.Backend.Application.Services.ParameterServices.CreateParameterCommands;
using AlfaguaraClub.Backend.Application.Services.ParameterServices.QueryParameterCommands;
using AlfaguaraClub.Backend.Application.Services.ParameterServices.UpdateParameterCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ParameterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllParameters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ParameterListVm>>> GetAllParameters()
        {
            var parameters = await _mediator.Send(new GetParameterListQuery());
            return Ok(parameters);
        }
        [HttpGet("/GetParameterByName/{name}", Name = "GetParameterByName")]
        public async Task<ActionResult<ParameterListVm>> GetParameterByName(string name)
        {
            var parameter = new GetParameterQuery() { ParameterName = name };
            return Ok(await _mediator.Send(parameter));
        }
        [HttpPost(Name = "AddParameter"), Authorize]
        public async Task<ActionResult<CreateParameterCommandResponse>> Create([FromBody] CreateParameterCommand createParameterCommand)
        {
            var newParameter = await _mediator.Send(createParameterCommand);
            return Ok(newParameter);
        }

        [HttpPut(Name = "UpdateParameter"), Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody]UpdateParameterCommand updateParameterCommand)
        {
            await _mediator.Send(updateParameterCommand);
            return NoContent();
        }
    }
}
