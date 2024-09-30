using AlfaguaraClub.Backend.Application.Services.UserInfoServices.CreateUserInfoCommands;
using AlfaguaraClub.Backend.Application.Services.UserInfoServices.QueryUserInfoCommands;
using AlfaguaraClub.Backend.Application.Services.UserInfoServices.UpdateUserInfoCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IMediator _mediator;            
        public UserInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetUserInfoByDocument/{documentNumber}", Name = "GetUserInfoByDocument")]
        public async Task<ActionResult<UserInfoVm>> GetUserInfoByDocument(string documentNumber)
        {
            var userInfo = new GetUserInfoQuery() { IdentificationNumber = documentNumber };
            return Ok(await _mediator.Send(userInfo));
        }
        [HttpPost(Name ="AddUserInfo")]
        public async Task<ActionResult<CreateUserInfoCommandResponse>> Create([FromBody] CreateUserInfoCommand createUserInfoCommand)
        {
            var newUserInfo = await _mediator.Send(createUserInfoCommand);
            return Ok(newUserInfo);
        }
        [HttpPut(Name = "UpdateUserInfo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateUserInfoCommand updateUserInfoCommand)
        {
            await _mediator.Send(updateUserInfoCommand);
            return NoContent();
        }

    }
}
