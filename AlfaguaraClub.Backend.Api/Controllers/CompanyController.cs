using AlfaguaraClub.Backend.Application.Services.CompanyServices;
using AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands;
using AlfaguaraClub.Backend.Application.Services.CompanyServices.UpdateCompanyCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllCompanies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CompanyListVm>>> GetAllCompanies()
        {
            var companies = await _mediator.Send(new GetCompanyListQuery());
            return companies;
        }

        [HttpPost(Name = "AddCompany")]
        public async Task<ActionResult<CreateCompanyCommandResponse>> Create ([FromBody] CreateCompanyCommand createCompanyCommand)
        {
            var response = await _mediator.Send(createCompanyCommand);
            return Ok(response);
        }
        [HttpPut(Name = "UpdateCompany"), Authorize ]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>Update([FromBody] UpdateCompanyCommand updateCompanyCommand)
        {
            await _mediator.Send(updateCompanyCommand);
            return NoContent();
        }
    }
}
