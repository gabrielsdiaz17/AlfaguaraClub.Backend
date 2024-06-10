using AlfaguaraClub.Backend.Application.Services.CostcenterServices.CreateCostCenterCommands;
using AlfaguaraClub.Backend.Application.Services.CostcenterServices.QueryCostCenterCommands;
using AlfaguaraClub.Backend.Application.Services.CostcenterServices.UpdateCostCenterCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostCenterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CostCenterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllCostCenters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CostCenterListVm>>> GetAllCostCenters()
        {
            var costCenters = await _mediator.Send(new GetCostCenterListQuery());
            return Ok(costCenters);
        }
        [HttpGet("/GetCostCenterById/{id}", Name = "GetCostCenterById")]
        public async Task<ActionResult<CostCenterListVm>> GetCostCenterById(long id)
        {
            var costCenter = new GetCostCenterQuery() { CostCenterId = id };
            return Ok(await _mediator.Send(costCenter));
        }
        [HttpPost(Name ="AddCostCenter")]
        public async Task<ActionResult<CreateCostCenterCommandResponse>> Create([FromBody]CreateCostCenterCommand createCostCenterCommand)
        {
            var response = await _mediator.Send(createCostCenterCommand);
            return Ok(response);
        }
        [HttpPut(Name ="UpdateCostCenter")]
        public async Task<ActionResult> Update([FromBody] UpdateCostCenterCommand updateCostCenterCommand)
        {
            await _mediator.Send(updateCostCenterCommand);
            return NoContent();
        }

    }
}
