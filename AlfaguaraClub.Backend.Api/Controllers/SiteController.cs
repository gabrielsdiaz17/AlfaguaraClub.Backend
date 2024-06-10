using AlfaguaraClub.Backend.Application.Services.SiteServices.CreateSiteCommands;
using AlfaguaraClub.Backend.Application.Services.SiteServices.QuerySiteCommands;
using AlfaguaraClub.Backend.Application.Services.SiteServices.UpdateCompanyCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SiteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllSites")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<SiteListVm>>> GetAllSites()
        {
            var sites = await _mediator.Send(new GetSiteListQuery());
            return Ok(sites);
        }
        [HttpPost(Name = "AddSite")]
        public async Task<ActionResult<CreateSiteCommandResponse>> AddSite([FromBody] CreateSiteCommand createSiteCommand)
        {
            var newSite = await _mediator.Send(createSiteCommand);
            return Ok(newSite);
        }
        [HttpPut(Name = "UpdateSite")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateSiteCommand updateSiteCommand)
        {
            await _mediator.Send(updateSiteCommand);
            return NoContent();
        }
    }
}
