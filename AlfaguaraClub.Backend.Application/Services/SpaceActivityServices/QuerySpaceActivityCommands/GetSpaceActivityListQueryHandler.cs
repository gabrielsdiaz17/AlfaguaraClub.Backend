using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.QuerySpaceActivityCommands
{
    public class GetSpaceActivityListQueryHandler : IRequestHandler<GetSpaceActivityListQuery, List<SpaceActivityListVm>>
    {
        private readonly ISpaceActivityRepository _spaceActivityRepository;
        private readonly IMapper _mapper;
        public GetSpaceActivityListQueryHandler(ISpaceActivityRepository spaceActivityRepository, IMapper mapper)
        {
            _spaceActivityRepository = spaceActivityRepository;
            _mapper = mapper;
        }

        public async Task<List<SpaceActivityListVm>> Handle(GetSpaceActivityListQuery request, CancellationToken cancellationToken)
        {
            var activities = await _spaceActivityRepository.GetSpaceActivitiesWithBooking();
            return _mapper.Map<List<SpaceActivityListVm>>(activities);
        }
    }
}
