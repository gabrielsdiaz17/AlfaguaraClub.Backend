using AlfaguaraClub.Backend.Application.Services.NotificationServices.CreateNotificationCommands;
using AlfaguaraClub.Backend.Application.Services.NotificationServices.QueryNotificationCommands;
using AlfaguaraClub.Backend.Application.Services.NotificationServices.UpdateNotificationCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationController(IMediator mediator)
        {
            
        }
        [HttpGet(Name = "GetAllNotifications")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<NotificationListVm>> GetAllNotifications()
        {
            var notifications = await _mediator.Send(new GetQueryNotificationList());
            return Ok(notifications);
        }

        [HttpGet("/GetNotificationById/{id}", Name = "GetNotificationById")]
        public async Task<ActionResult<NotificationListVm>> GetNotificationById(long id)
        {
            var notification = new GetNotificationQuery() { NotificationId = id };
            return Ok(await _mediator.Send(notification));
        }
        [HttpGet("/GetNotificationByNotificationType/{id}", Name = "GetNotificationByNotificationType")]
        public async Task<ActionResult<NotificationListVm>> GetNotificationByNotificationType(int id)
        {
            var notifications = new GetNotificationQueryByNotificationType() { NotificationType = id };
            return Ok(await _mediator.Send(notifications));
        }

        [HttpPost("/GetNotificationByStateDate/", Name = "GetNotificationByStateDate")]
        public async Task<ActionResult<NotificationListVm>> GetNotificationByStateDate([FromBody] GetNotificationQueryByStateAndDate query)
        {
            var notifications = await _mediator.Send(query);
            return Ok(notifications);
        }
        [HttpPost(Name ="AddNotification")]
        public async Task<ActionResult<CreateNotificationCommandResponse>> Create([FromBody] CreateNotificationCommand createNotificationCommand)
        {
            var newNotification = await _mediator.Send(createNotificationCommand);
            return Ok(newNotification);
        }
        [HttpPut(Name = "UpdateNotificaion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateNotificationCommand updateNotificationCommand)
        {
            await _mediator.Send(updateNotificationCommand);
            return NoContent();
        }
    }
}
