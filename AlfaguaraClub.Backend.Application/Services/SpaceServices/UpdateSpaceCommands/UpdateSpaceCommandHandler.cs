using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.UpdateSpaceCommands
{
    public class UpdateSpaceCommandHandler : IRequestHandler<UpdateSpaceCommand>
    {
        private readonly ISpaceRepository _spaceRepository;
        private readonly IMapper _mapper;
        public UpdateSpaceCommandHandler(ISpaceRepository spaceRepository, IMapper mapper)
        {
            _spaceRepository = spaceRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSpaceCommand request, CancellationToken cancellationToken)
        {
            var spaceToUpdate = await _spaceRepository.GetByIdAsync(request.SpaceId);
            if (spaceToUpdate == null) { }
            _mapper.Map(request, spaceToUpdate, typeof(UpdateSpaceCommand), typeof(Space));
            await _spaceRepository.UpdateAsync(spaceToUpdate);
        }
    }
}
