using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Exceptions;
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
            if (spaceToUpdate == null)
                throw new NotFoundException(nameof(Space), request.SpaceId);
            var validator = new UpdateSpaceCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Count > 0)            
                throw new ValidationException(validationResult);
            
            _mapper.Map(request, spaceToUpdate, typeof(UpdateSpaceCommand), typeof(Space));
            await _spaceRepository.UpdateAsync(spaceToUpdate);
        }
    }
}
