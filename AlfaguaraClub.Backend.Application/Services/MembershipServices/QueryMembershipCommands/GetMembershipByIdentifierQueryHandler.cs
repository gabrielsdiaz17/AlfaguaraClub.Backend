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
    public class GetMembershipByIdentifierQueryHandler : IRequestHandler<GetMembershipByIdentifierQuery, MembershipListVm>
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;
        public GetMembershipByIdentifierQueryHandler(IMembershipRepository membershipRepository, IMapper mapper)
        {
            _membershipRepository = membershipRepository;
            _mapper = mapper;
        }

        public async Task<MembershipListVm> Handle(GetMembershipByIdentifierQuery request, CancellationToken cancellationToken)
        {
            var membership = await _membershipRepository.GetMembershipByIdentifier(request.Identifier);
            return _mapper.Map<MembershipListVm>(membership);
        }
    }
}
