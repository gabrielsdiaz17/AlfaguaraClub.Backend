using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.QuerySpaceActivityCommands
{
    public class GetSpaceActivityBySpaceQueryHandler : IRequestHandler<GetSpaceActivityBySpaceQuery, List<SpaceActivityListVm>>
    {
        private readonly ISpaceActivityRepository _spaceActivityRepository;
        private readonly IMapper _mapper;
        public GetSpaceActivityBySpaceQueryHandler(ISpaceActivityRepository spaceActivityRepository, IMapper mapper)
        {
            _spaceActivityRepository = spaceActivityRepository;
            _mapper = mapper;
        }

        public async Task<List<SpaceActivityListVm>> Handle(GetSpaceActivityBySpaceQuery request, CancellationToken cancellationToken)
        {
            var activitiesBySpace = await _spaceActivityRepository.GetSpaceActivityBySpace(request.SpaceId);
            if(activitiesBySpace == null) { }
            return _mapper.Map<List<SpaceActivityListVm>>(activitiesBySpace);
        }
    }
}
