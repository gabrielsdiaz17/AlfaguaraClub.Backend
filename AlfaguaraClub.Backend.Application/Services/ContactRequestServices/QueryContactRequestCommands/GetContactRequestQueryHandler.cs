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
    public class GetContactRequestQueryHandler : IRequestHandler<GetContactRequestQuery, List<ContactRequestListVm>>
    {
        private readonly IContactRequestRepository _contactRequestRepository;
        private readonly IMapper _mapper;
        public GetContactRequestQueryHandler(IContactRequestRepository contactRequestRepository, IMapper mapper)
        {
            _contactRequestRepository = contactRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<ContactRequestListVm>> Handle(GetContactRequestQuery request, CancellationToken cancellationToken)
        {
            var allContactRequest = await _contactRequestRepository.GetAllRequest();
            return _mapper.Map<List<ContactRequestListVm>>(allContactRequest);
        }
    }
}
