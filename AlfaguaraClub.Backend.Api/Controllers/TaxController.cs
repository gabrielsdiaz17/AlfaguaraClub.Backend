using AlfaguaraClub.Backend.Application.Services.TaxServices.CreateTaxCommands;
using AlfaguaraClub.Backend.Application.Services.TaxServices.QueryTaxCommands;
using AlfaguaraClub.Backend.Application.Services.TaxServices.UpdateTaxCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaxController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllTaxes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<TaxListVm>>> GetAllTaxes()
        {
            var taxes = await _mediator.Send(new GetListTaxQuery());
            return Ok(taxes);
        }
        [HttpGet("/GetTaxById/{id}", Name = "GetTaxById")]
        public async Task<ActionResult<TaxListVm>> GetTaxById(int id)
        {
            var tax = new GetTaxQuery() { TaxId = id };
            return Ok(await _mediator.Send(tax));
        }

        [HttpGet("/GetTaxByName/{name}", Name = "GetTaxByName")]
        public async Task<ActionResult<TaxListVm>> GetTaxByName(string name)
        {
            var tax = new GetTaxByNameQuery() { TaxName = name };
            return Ok(await _mediator.Send(tax));
        }
        [HttpPost(Name = "AddTax")]
        public async Task<ActionResult<CreateTaxCommandResponse>> Create([FromBody] CreateTaxCommand createTaxCommand)
        {
            var newTax = await _mediator.Send(createTaxCommand);
            return Ok(newTax);
        }
        [HttpPut(Name = "UpdateTax")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task <ActionResult> Update([FromBody] UpdateTaxCommand updateTaxCommand)
        {
            await _mediator.Send(updateTaxCommand);
            return NoContent();
        }
    }
}
