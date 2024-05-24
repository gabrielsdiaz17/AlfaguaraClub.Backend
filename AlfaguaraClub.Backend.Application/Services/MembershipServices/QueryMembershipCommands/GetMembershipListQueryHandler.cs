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
    public class GetMembershipListQueryHandler : IRequestHandler<GetMembershipListQuery, List<MembershipListVm>>
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;
        public GetMembershipListQueryHandler(IMembershipRepository membershipRepository, IMapper mapper)
        {
            _membershipRepository = membershipRepository;
            _mapper = mapper;
        }

        public async Task<List<MembershipListVm>> Handle(GetMembershipListQuery request, CancellationToken cancellationToken)
        {
            var memberships = await _membershipRepository.GetAllMemberships();
            return _mapper.Map<List<MembershipListVm>>(memberships);    
        }
    }
}
