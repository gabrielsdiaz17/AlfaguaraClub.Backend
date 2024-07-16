using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ContactRequestServices.QueryContactRequestCommands
{
    public class GetContactRequestBySpaceQueryHandler : IRequestHandler<GetContactRequestBySpace, List<ContactRequestListVm>>
    {
        private readonly IContactRequestRepository _contactRequestRepository;
        private readonly IMapper _mapper;
        public GetContactRequestBySpaceQueryHandler(IContactRequestRepository contactRequestRepository, IMapper mapper)
        {
            _contactRequestRepository = contactRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<ContactRequestListVm>> Handle(GetContactRequestBySpace request, CancellationToken cancellationToken)
        {
            var query = await _contactRequestRepository.GetRequestBySpaceId(request.SpaceId);
            return _mapper.Map<List<ContactRequestListVm>>(query);
        }
    }
}
