using AlfaguaraClub.Backend.Application.Services.NotificationServices.UpdateNotificationCommands;
using AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.CreateNotificationTypeCommands;
using AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.QueryNotificationTypeCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationTypeController : ControllerBase
    {
        private IMediator _mediator;
        public NotificationTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetNotificationType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<NotificationTypeListVm>>> GetNotificationType()
        {
            var notificationList = await _mediator.Send(new GetQueryIdentificationTypeListQuery());
            return Ok(notificationList);
        }
        [HttpPost(Name = "AddNotificationType")]
        public async Task<ActionResult<CreateNotificationTypeCommandResponse>> Create([FromBody] CreateNotificationTypeCommand command)
        {
            var newNotificationType = await _mediator.Send(command);
            return Ok(newNotificationType);
        }
        [HttpPut(Name = "UpdateNotificationType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task <ActionResult> Update([FromBody] UpdateNotificationCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
