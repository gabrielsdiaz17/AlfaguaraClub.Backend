using AlfaguaraClub.Backend.Application.Services.BookingServices.CreateBookingCommands;
using AlfaguaraClub.Backend.Application.Services.BookingServices.QueryBookingCommands;
using AlfaguaraClub.Backend.Application.Services.BookingServices.UpdateBookingCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetBookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<BookingListVm>>> GetBookings()
        {
            var bookings = await _mediator.Send(new GetBookingListQuery());
            return Ok(bookings);
        }

        [HttpGet("/GetBookingById/{id}", Name = "GetBookingById")]
        public async Task<ActionResult<BookingListVm>> GetBookingById(long id)
        {
            var booking = new GetBookingByBookingQuery() { BookingId = id };
            return Ok(await _mediator.Send(booking));
        }

        [HttpGet("/GetBookingByMembership/{id}", Name = "GetBookingByMembership")]
        public async Task<ActionResult<List<BookingListVm>>> GetBookingByMembership(long id)
        {
            var bookingsByMembership = new GetBookingsByMembershipQuery() { MembershipId = id };
            return Ok( await _mediator.Send(bookingsByMembership));
        }

        [HttpGet("/GetBookingBySpaceActivity/{id}", Name = "GetBookingBySpaceActivity")]
        public async Task<ActionResult<List<BookingListVm>>> GetBookingBySpaceActivity(long id)
        {
            var bookingsBySpaceActivity = new GetBookingsBySpaceActivityQuery() { SpaceActivityId = id };
            return Ok(await _mediator.Send(bookingsBySpaceActivity));
        }

        [HttpPost(Name = "AddBooking")]
        public async Task<ActionResult<CreateBookingCommandResponse>> Create([FromBody] CreateBookingCommand createBookingCommand)
        {
            var newBooking = await _mediator.Send(createBookingCommand);
            return Ok(newBooking);
        }

        [HttpPut(Name ="UpdateBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBookingCommand updateBookingCommand)
        {
            await _mediator.Send(updateBookingCommand);
            return NoContent();
        }

    }
}
