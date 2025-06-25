using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Exceptions;
using AlfaguaraClub.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SquashFieldActivityServices.UpdateSquashFieldActivityCommands
{
    public class UpdateSlotForSquashFieldCommandHandler : IRequestHandler<UpdateSlotForSquashFieldCommand>
    {
        private readonly ISquashFieldActivitySlotRepository _squashFieldActivitySlotRepository;
        public UpdateSlotForSquashFieldCommandHandler(ISquashFieldActivitySlotRepository squashFieldActivitySlotRepository)
        {
            _squashFieldActivitySlotRepository = squashFieldActivitySlotRepository;
        }

        public async Task Handle(UpdateSlotForSquashFieldCommand request, CancellationToken cancellationToken)
        {
            var squashFieldActivity = await _squashFieldActivitySlotRepository.GetByIdAsync(request.SquashFieldActivitySlotId);
            if (squashFieldActivity == null)
                throw new NotFoundException(nameof(SquashFieldActivitySlot), request.SquashFieldActivitySlotId);
            squashFieldActivity.AvailableSlots = request.AvailableSlots;
            squashFieldActivity.IsActive = request.IsActive;
            await _squashFieldActivitySlotRepository.UpdateAsync(squashFieldActivity);
        }
    }
}
