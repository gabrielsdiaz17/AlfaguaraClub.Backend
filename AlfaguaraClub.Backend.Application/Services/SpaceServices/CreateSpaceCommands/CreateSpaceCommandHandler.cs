using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.CreateSpaceCommands
{
    public class CreateSpaceCommandHandler : IRequestHandler<CreateSpaceCommand, long>
    {
        private readonly ISpaceRepository _spaceRepository;
        private readonly IMapper _mapper;
        public CreateSpaceCommandHandler(ISpaceRepository spaceRepository, IMapper mapper)
        {
            _spaceRepository = spaceRepository;
            _mapper = mapper;
        }
        public async Task<long> Handle(CreateSpaceCommand request, CancellationToken cancellationToken)
        {
            var space = _mapper.Map<Space>(request);
            space = await _spaceRepository.AddAsync(space);
            return space.SpaceId;
        }
    }
}
