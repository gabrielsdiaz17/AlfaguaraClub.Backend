using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands
{
    public class GetMembershipQueryHandler : IRequestHandler<GetMemberShipQuery, MembershipListVm>
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;
        public GetMembershipQueryHandler(IMembershipRepository membershipRepository, IMapper mapper)
        {
            _membershipRepository = membershipRepository;
            _mapper = mapper;
        }

        public async Task<MembershipListVm> Handle(GetMemberShipQuery request, CancellationToken cancellationToken)
        {
            var membership = await _membershipRepository.GetMembershipWithUsers(request.MembershipId);
            return _mapper.Map<MembershipListVm>(membership);
        }
    }
}
