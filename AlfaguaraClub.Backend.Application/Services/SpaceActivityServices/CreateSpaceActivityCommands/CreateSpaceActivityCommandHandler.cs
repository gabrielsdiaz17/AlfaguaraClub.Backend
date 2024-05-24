using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.CreateSpaceActivityCommands
{
    public class CreateSpaceActivityCommandHandler : IRequestHandler<CreateSpaceActivityCommand, long>
    {
        private readonly ISpaceActivityRepository _spaceActivityRepository;
        private readonly IMapper _mapper;
        public CreateSpaceActivityCommandHandler(ISpaceActivityRepository spaceActivityRepository, IMapper mapper)
        {
            _spaceActivityRepository = spaceActivityRepository;
            _mapper = mapper;
        }
        public async Task<long> Handle(CreateSpaceActivityCommand request, CancellationToken cancellationToken)
        {
            var spaceActivity = _mapper.Map<SpaceActivity>(request);
            spaceActivity = await _spaceActivityRepository.AddAsync(spaceActivity);
            return spaceActivity.SpaceActivityId;
        }
    }
}
