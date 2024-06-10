using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.MembershipServices.CreateMembershipCommands
{
    public class CreateMembershipCommandHandler : IRequestHandler<CreateMembershipCommand, CreateMembershipCommandResponse>
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;
        public CreateMembershipCommandHandler(IMembershipRepository membershipRepository, IMapper mapper)
        {
            _membershipRepository = membershipRepository;
            _mapper = mapper;
        }

        public async Task<CreateMembershipCommandResponse> Handle(CreateMembershipCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateMembershipCommandResponse();
            var newMemberShip = _mapper.Map<Membership>(request);
            var validator = new CreateMembershipCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count >0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                newMemberShip = await _membershipRepository.AddAsync(newMemberShip);
                response.MembershipId = newMemberShip.MembershipId;
            }
            
            return response;
        }
    }
}
