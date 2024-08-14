using AlfaguaraClub.Backend.Application.Services.UserServices.CreateUserCommands;
using AlfaguaraClub.Backend.Application.Services.UserServices.QueryUserCommands;
using AlfaguaraClub.Backend.Application.Services.UserServices.UpdateUserCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet(Name = "GetAllUsers"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<UserListVm>>> GetAllUsers()
        {
            var users = await _mediator.Send(new GetUserListQuery());
            return Ok(users);
        }
        [HttpGet("GetUserById/{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserListVm>> GetUserById(long id)
        {
            var user = new GetUserQuery() { UserId = id };
            return Ok(await _mediator.Send(user));
        }

        [HttpPost("GetUserLogin", Name = "GetUserLogin")]
        public async Task<ActionResult<GetUserLoginQueryCommandResponse>> GetUserLogin([FromBody] GetUserLoginQuery query)
        {
            var userLogin = await _mediator.Send(query);
            if (!userLogin.Success) { }
            return Ok(userLogin);
        }
        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<CreateUserCommandResponse>> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var newUser = await _mediator.Send(createUserCommand);
            return Ok(newUser);
        }
        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            await _mediator.Send(updateUserCommand);
            return NoContent();
        }

        [HttpPut("UpdateUserPassword", Name = "UpdateUserPassword")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateUserPassword([FromBody] UpdateUserPasswordCommand updateUserCommand)
        {
            await _mediator.Send(updateUserCommand);
            return NoContent();
        }
    }
}
