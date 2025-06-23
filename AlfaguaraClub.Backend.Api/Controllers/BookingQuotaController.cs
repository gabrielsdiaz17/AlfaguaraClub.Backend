using AlfaguaraClub.Backend.Application.Services.BookingQuotaServices.CreateBookingQuotaCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingQuotaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingQuotaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name ="AddBookingQuota"), Authorize]
        public async Task<ActionResult<CreateBookingQuotaCommandResponse>> Create([FromBody] CreateBookingQuotaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
