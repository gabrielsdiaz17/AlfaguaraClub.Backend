﻿using AlfaguaraClub.Backend.Application.Services.MembershipServices.CreateMembershipCommands;
using AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands;
using AlfaguaraClub.Backend.Application.Services.MembershipServices.UpdateMembershipCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlfaguaraClub.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MembershipController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetMemberships"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<MembershipListVm>>> GetMemberships()
        {
            var memberships = await _mediator.Send(new GetMembershipListQuery());
            return memberships;
        }
        [HttpGet("GetMembershipById/{id}", Name = "GetMembershipById"), Authorize]
        public async Task<ActionResult<MembershipListVm>> GetMembershipById(long id) 
        {
            var membership = new GetMemberShipQuery() { MembershipId = id };
            return await _mediator.Send(membership);
        }

        [HttpGet("GetMembershipByUniqueIdentifier/{identifier}", Name = "GetMembershipByUniqueIdentifier")]
        public async Task<ActionResult<MembershipListVm>> GetMembershipByUniqueIdentifier(string identifier)
        {
            var membership = new GetMembershipByIdentifierQuery() { Identifier = identifier };
            return await _mediator.Send(membership);
        }

        [HttpPost(Name = "AddMembership"), Authorize]
        public async Task<ActionResult<CreateMembershipCommandResponse>> Create([FromBody] CreateMembershipCommand createMembershipCommand)
        {
            var response = await _mediator.Send(createMembershipCommand);
            return response;
        }
        [HttpPut(Name = "UpdateMembership"), Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateMembershipCommand updateMembershipCommand)
        {
            await _mediator.Send(updateMembershipCommand);
            return NoContent();
        }
    }
}
