using AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.CreatePaymentMethodCommands;
using AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.QueryPaymentMethodCommands;
using AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.UpdatePaymentMethodCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentMethodController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllPaymentMethods")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PaymentMethodListVm>>> GetAllPaymentMethods()
        {
            var paymentMethods = await _mediator.Send(new GetPaymentMethodListQuery());
            return Ok(paymentMethods);
        }

        [HttpPost(Name = "AddPaymentMethod")]
        public async Task<ActionResult<CreatePaymentMethodCommandResponse>> Create([FromBody] CreatePaymentMethodCommand createPaymentMethodCommand)
        {
            var newPaymentMethod = await _mediator.Send(createPaymentMethodCommand);
            return Ok(newPaymentMethod);
        }

        [HttpPut(Name = "UpdatePaymentMthod")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdatePaymentMethodCommand updatePaymentMethodCommand)
        {
            await _mediator.Send(updatePaymentMethodCommand);
            return NoContent();
        }
    }
}
