using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.QuerySpaceCommands
{
    public class GetSpaceQueryHandler : IRequestHandler<GetSpaceQuery, SpaceListVm>
    {
        private readonly ISpaceRepository _spaceRepository;
        private readonly IMapper _mapper;
        public GetSpaceQueryHandler(ISpaceRepository spaceRepository, IMapper mapper)
        {
            _spaceRepository = spaceRepository;
            _mapper = mapper;
        }
        public async Task<SpaceListVm> Handle(GetSpaceQuery request, CancellationToken cancellationToken)
        {
            var space = await _spaceRepository.GetSpace(request.SpaceId);
            return _mapper.Map<SpaceListVm>(space);
        }
    }
}
