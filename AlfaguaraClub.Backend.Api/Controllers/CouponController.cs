using AlfaguaraClub.Backend.Application.Services.CouponServices.CouponBookQueryCommands;
using AlfaguaraClub.Backend.Application.Services.CouponServices.CouponPurchasesQueryCommands;
using AlfaguaraClub.Backend.Application.Services.CouponServices.CreateCouponPurchaseCommands;
using AlfaguaraClub.Backend.Application.Services.CouponServices.CreateMonthlyCouponCommands;
using AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CouponController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateCouponBook"), Authorize]
        public async Task<ActionResult<CreateCouponBookResponse>> CreateCouponBook([FromBody] CreateCouponBookCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("AddPurchase"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AddCouponPurchaseResponse>> AddPurchase([FromBody] AddCouponPurchaseCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetCouponBooksByMonth"), Authorize]
        public async Task<ActionResult<List<CouponBookVm>>> GetCouponBooksByMonth([FromQuery] DateTime month)
        {
            var result = await _mediator.Send(new GetCouponBooksByMonthQuery { Month = month });
            return Ok(result);
        }

        [HttpGet("GetPurchasesByBookId"), Authorize]
        public async Task<ActionResult<List<CouponPurchaseVm>>> GetPurchasesByBookId([FromQuery] long bookId)
        {
            var result = await _mediator.Send(new GetCouponPurchasesByBookIdQuery { MonthlyCouponBookId = bookId });
            return Ok(result);
        }

        [HttpGet("GetPurchasesByMembership"), Authorize]
        public async Task<ActionResult<List<CouponPurchaseVm>>> GetPurchasesByMembership([FromQuery] long membershipId, [FromQuery] DateTime month)
        {
            var result = await _mediator.Send(new GetCouponPurchasesByMembershipQuery { MembershipId = membershipId, Month = month });
            return Ok(result);
        }
        [HttpGet("GetUnpaidMemberships")]
        public async Task<ActionResult<List<MembershipListVm>>> GetUnpaidMemberships([FromQuery] DateTime month)
        {
            var result = await _mediator.Send(new GetUnpaidMembershipsForMonthQuery { Month = month });
            return Ok(result);
        }
    }
}
