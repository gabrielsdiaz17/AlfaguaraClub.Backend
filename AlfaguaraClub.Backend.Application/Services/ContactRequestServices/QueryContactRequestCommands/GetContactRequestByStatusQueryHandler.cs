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
    public class GetContactRequestByStatusQueryHandler : IRequestHandler<GetContactRequestByStatus, List<ContactRequestListVm>>
    {
        private readonly IContactRequestRepository _contactRequestRepository;
        private readonly IMapper _mapper;
        public GetContactRequestByStatusQueryHandler(IContactRequestRepository contactRequestRepository, IMapper mapper)
        {
            _contactRequestRepository = contactRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<ContactRequestListVm>> Handle(GetContactRequestByStatus request, CancellationToken cancellationToken)
        {
            var contactStatus = await _contactRequestRepository.GetRequestByStatus(request.Status);
            return _mapper.Map<List<ContactRequestListVm>>(contactStatus);
        }
    }
}
