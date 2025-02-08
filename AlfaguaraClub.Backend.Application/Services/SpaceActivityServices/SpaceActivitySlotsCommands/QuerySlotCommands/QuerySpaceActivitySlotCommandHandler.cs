using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.SpaceActivitySlotsCommands.QuerySlotCommands
{
    public class QuerySpaceActivitySlotCommandHandler : IRequestHandler<QuerySpaceActivitySlotCommand,List<SpaceActivitySlotVm>>
    {
        private readonly ISpaceActivitySlotRepository _spaceActivitySlotRepository;
        private readonly IMapper _mapper;
        public QuerySpaceActivitySlotCommandHandler(ISpaceActivitySlotRepository spaceActivitySlotRepository, IMapper mapper)
        {
            _spaceActivitySlotRepository = spaceActivitySlotRepository;
            _mapper = mapper;
        }

        public async Task<List<SpaceActivitySlotVm>> Handle(QuerySpaceActivitySlotCommand request, CancellationToken cancellationToken)
        {
            var slots = await _spaceActivitySlotRepository.GetSlotsForSpaceActivity(request.SpaceActivityId);
            return _mapper.Map<List<SpaceActivitySlotVm>>(slots);
        }
    }
}
