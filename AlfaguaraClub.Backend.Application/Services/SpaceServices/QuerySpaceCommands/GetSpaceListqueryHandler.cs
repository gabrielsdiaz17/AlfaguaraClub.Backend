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
    public class GetSpaceListqueryHandler : IRequestHandler<GetSpaceListQuery, List<SpaceListVm>>
    {
        private readonly ISpaceRepository _spaceRepository;
        private readonly IMapper _mapper;
        public GetSpaceListqueryHandler(ISpaceRepository spaceRepository, IMapper mapper)
        {
            _spaceRepository = spaceRepository;
            _mapper = mapper;
        }

        public async Task<List<SpaceListVm>> Handle(GetSpaceListQuery request, CancellationToken cancellationToken)
        {
            var spaces = await _spaceRepository.GetSpacesWithImagesIncludeActivities(request.QuantityRecords);
            return _mapper.Map<List<SpaceListVm>>(spaces);
        }
    }
}
