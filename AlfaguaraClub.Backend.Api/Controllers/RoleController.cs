using AlfaguaraClub.Backend.Application.Services.RoleServices.CreateRoleCommands;
using AlfaguaraClub.Backend.Application.Services.RoleServices.QueryRoleCommands;
using AlfaguaraClub.Backend.Application.Services.RoleServices.UpdateRoleCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetRoles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RoleListVm>> GetRoles()
        {
            var roles = await _mediator.Send(new GetRoleListQuery());
            return Ok(roles);
        }
        [HttpGet("/GetRoleById/{id}", Name = "GetRoleById")]
        public async Task<ActionResult<RoleListVm>> GetRoleById(int roleId)
        {
            var role = new GetRoleQuery() { RoleId = roleId };
            return Ok(await _mediator.Send(role));
        }
        [HttpPost(Name = "AddRole")]
        public async Task<ActionResult<CreateRoleCommandResponse>> Create([FromBody] CreateRoleCommand createRoleCommand)
        {
            var newRole = await _mediator.Send(createRoleCommand);
            return Ok(newRole);
        }
        [HttpPut(Name = "UpdateRole")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateRoleCommand updateRoleCommand)
        {
            await _mediator.Send(updateRoleCommand);
            return NoContent();
        }
    }
}
