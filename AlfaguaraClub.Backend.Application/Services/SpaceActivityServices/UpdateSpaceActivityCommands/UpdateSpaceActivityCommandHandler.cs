using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.UpdateSpaceActivityCommands
{
    public class UpdateSpaceActivityCommandHandler : IRequestHandler<UpdateSpaceActivityCommand>
    {
        private readonly ISpaceActivityRepository _spaceActivityRepository;
        private IMapper _mapper;
        public UpdateSpaceActivityCommandHandler(ISpaceActivityRepository spaceActivityRepository, IMapper mapper)
        {
            _spaceActivityRepository = spaceActivityRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSpaceActivityCommand request, CancellationToken cancellationToken)
        {
            var spaceActivityToUpdate = await _spaceActivityRepository.GetByIdAsync(request.SpaceActivityId);
            if (spaceActivityToUpdate == null) { }
            _mapper.Map(request,spaceActivityToUpdate,typeof(UpdateSpaceActivityCommand),typeof(SpaceActivity));
            await _spaceActivityRepository.UpdateAsync(spaceActivityToUpdate);
        }
    }
}
