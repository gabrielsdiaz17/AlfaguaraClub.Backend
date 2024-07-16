using AlfaguaraClub.Backend.Application.Services.ContactRequestServices.CreateContactRequestCommands;
using AlfaguaraClub.Backend.Application.Services.ContactRequestServices.QueryContactRequestCommands;
using AlfaguaraClub.Backend.Application.Services.ContactRequestServices.UpdateContactRequestCommands;
using AlfaguaraClub.Backend.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllContactRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ContactRequestListVm>>> GetAllContactRequest()
        {
            var contactRequest = await _mediator.Send(new GetContactRequestQuery());
            return Ok(contactRequest);
        }
        [HttpGet("/GetContactRequestBySpace/{id}", Name = "GetContactRequestBySpace")]
        public async Task<ActionResult<List<ContactRequestListVm>>> GetContactRequestBySpace(long id)
        {
            var contactRequest = new GetContactRequestBySpace() { SpaceId = id };
            return Ok(await _mediator.Send(contactRequest));
        }
        [HttpGet("/GetContactRequestByStatus/{status}", Name = "GetContactRequestByStatus")]
        public async Task<ActionResult<List<ContactRequestListVm>>> GetContactRequestByStatus(StatusRequest status)
        {
            var contactRequest =  new GetContactRequestByStatus() { Status = status };
            return Ok(await _mediator.Send(contactRequest));
        }
        [HttpPost(Name ="AddContactRequest")]
        public async Task<ActionResult<CreateContactRequestCommandResponse>> Create([FromBody] CreateContactRequestCommand createContactRequestCommand)
        {
            var response = await _mediator.Send(createContactRequestCommand);
            return Ok(response);
        }
        [HttpPut(Name = "UpdateContactRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateContactRequestCommand updateContactRequestCommand)
        {
            await _mediator.Send(updateContactRequestCommand);
            return NoContent();
        }
    }
}
