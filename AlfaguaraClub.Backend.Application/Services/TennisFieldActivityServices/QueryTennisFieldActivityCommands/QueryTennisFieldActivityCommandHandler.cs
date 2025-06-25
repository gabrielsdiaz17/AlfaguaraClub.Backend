using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TennisFieldActivityServices.QueryTennisFieldActivityCommands
{
    public class QueryTennisFieldActivityCommandHandler : IRequestHandler<QueryTennisFieldActivityCommand, List<TennisFieldActivitySlotVm>>
    {
        private readonly ITennisFieldActivitySlotRepository _tennisFieldActivitySlotRepository;
        private readonly IMapper _mapper;
        public QueryTennisFieldActivityCommandHandler(ITennisFieldActivitySlotRepository tennisFieldActivitySlotRepository, IMapper mapper)
        {
            _tennisFieldActivitySlotRepository = tennisFieldActivitySlotRepository;
            _mapper = mapper;
        }

        public async Task<List<TennisFieldActivitySlotVm>> Handle(QueryTennisFieldActivityCommand request, CancellationToken cancellationToken)
        {
            var tennisSlots = await _tennisFieldActivitySlotRepository.GetTennisFieldSlotsForSpaceActivity(request.SpaceActivityId);
            return _mapper.Map<List<TennisFieldActivitySlotVm>>(tennisSlots);
        }
    }
}
