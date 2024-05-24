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
    public class CreateMembershipCommandHandler : IRequestHandler<CreateMembershipCommand, long>
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;
        public CreateMembershipCommandHandler(IMembershipRepository membershipRepository, IMapper mapper)
        {
            _membershipRepository = membershipRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateMembershipCommand request, CancellationToken cancellationToken)
        {
            var newMemberShip = _mapper.Map<Membership>(request);
            newMemberShip = await _membershipRepository.AddAsync(newMemberShip);
            return newMemberShip.MembershipId;
        }
    }
}
