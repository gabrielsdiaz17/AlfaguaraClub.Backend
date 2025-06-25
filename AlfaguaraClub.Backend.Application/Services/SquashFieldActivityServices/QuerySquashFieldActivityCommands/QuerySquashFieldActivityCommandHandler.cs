using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SquashFieldActivityServices.QuerySquashFieldActivityCommands
{
    public class QuerySquashFieldActivityCommandHandler : IRequestHandler<QuerySquashFieldActivityCommand, List<SquashFieldActivitySlotVm>>
    {
        private readonly ISquashFieldActivitySlotRepository _squashFieldActivitySlotRepository;
        private readonly IMapper _mapper;
        public QuerySquashFieldActivityCommandHandler(ISquashFieldActivitySlotRepository squashFieldActivitySlotRepository, IMapper mapper)
        {
            _mapper = mapper;
            _squashFieldActivitySlotRepository = squashFieldActivitySlotRepository;
        }
        public async Task<List<SquashFieldActivitySlotVm>> Handle(QuerySquashFieldActivityCommand request, CancellationToken cancellationToken)
        {
            var squashSlots = await _squashFieldActivitySlotRepository.GetSquashSlotsFroSpaceActivity(request.SpaceActivityId);
            return _mapper.Map<List<SquashFieldActivitySlotVm>>(squashSlots);
        }
    }
}
