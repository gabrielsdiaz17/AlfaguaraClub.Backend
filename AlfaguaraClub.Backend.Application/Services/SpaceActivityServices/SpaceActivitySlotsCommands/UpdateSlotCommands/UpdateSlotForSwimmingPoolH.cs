using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Exceptions;
using AlfaguaraClub.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.SpaceActivitySlotsCommands.UpdateSlotCommands
{
    public class UpdateSlotForSwimmingPoolH : IRequestHandler<UpdateSlotForSwimmingPool>
    {
        private readonly ISpaceActivitySlotRepository _spaceActivitySlotRepository;
        public UpdateSlotForSwimmingPoolH(ISpaceActivitySlotRepository spaceActivitySlotRepository)
        {
            _spaceActivitySlotRepository = spaceActivitySlotRepository;
        }

        public async Task Handle(UpdateSlotForSwimmingPool request, CancellationToken cancellationToken)
        {
            var spaceActivitySlot = await _spaceActivitySlotRepository.GetByIdAsync(request.SpaceActivitySlotId);
            if (spaceActivitySlot == null)
                throw new NotFoundException(nameof(SpaceActivitySlot), request.SpaceActivitySlotId);
            spaceActivitySlot.CurrentQuorum = request.CurrentQuorum;

            await _spaceActivitySlotRepository.UpdateAsync(spaceActivitySlot);
        }
    }
}
