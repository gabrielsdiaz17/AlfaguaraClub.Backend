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
    public class GetSpaceActivityQueryHandler : IRequestHandler<GetSpaceActivityQuery, SpaceActivityListVm>
    {
        private readonly ISpaceActivityRepository _spaceActivityRepository;
        private readonly IMapper _mapper;
        public GetSpaceActivityQueryHandler(ISpaceActivityRepository spaceActivityRepository, IMapper mapper)
        {
            _spaceActivityRepository = spaceActivityRepository;
            _mapper = mapper;
        }

        public async Task<SpaceActivityListVm> Handle(GetSpaceActivityQuery request, CancellationToken cancellationToken)
        {
            var spaceActivity = await _spaceActivityRepository.GetSingleSpaceActivity(request.SpaceActivityId);
            if (spaceActivity == null) { }
            return _mapper.Map<SpaceActivityListVm>(spaceActivity);
        }
    }
}
