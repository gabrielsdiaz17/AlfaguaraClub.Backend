using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.MembershipServices.UpdateMembershipCommands
{
    public class UpdateMembershipCommandHandler : IRequestHandler<UpdateMembershipCommand>
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;
        public UpdateMembershipCommandHandler(IMembershipRepository membershipRepository, IMapper mapper)
        {
            _membershipRepository = membershipRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateMembershipCommand request, CancellationToken cancellationToken)
        {
            var membershipToUpdate = await _membershipRepository.GetByIdAsync(request.MembershipId);
            if (membershipToUpdate == null) { }
            _mapper.Map(request, membershipToUpdate, typeof(UpdateMembershipCommand),typeof(Membership));
            await _membershipRepository.UpdateAsync(membershipToUpdate);
        }
    }
}
