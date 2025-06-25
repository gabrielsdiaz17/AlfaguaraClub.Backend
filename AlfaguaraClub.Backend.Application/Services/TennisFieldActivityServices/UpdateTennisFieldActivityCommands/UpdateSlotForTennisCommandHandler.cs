using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TennisFieldActivityServices.UpdateTennisFieldActivityCommands
{
    public class UpdateSlotForTennisCommandHandler : IRequestHandler<UpdateSlotForTennisCommand>
    {
        private readonly ITennisFieldActivitySlotRepository _tennisFieldActivitySlotRepository;
        public UpdateSlotForTennisCommandHandler(ITennisFieldActivitySlotRepository tennisFieldActivitySlotRepository)
        {
            _tennisFieldActivitySlotRepository = tennisFieldActivitySlotRepository;
        }
        public async Task Handle(UpdateSlotForTennisCommand request, CancellationToken cancellationToken)
        {
            var tennisActivitySlot = await _tennisFieldActivitySlotRepository.GetByIdAsync(request.TennisFieldActivitySlotId);
            if (tennisActivitySlot == null) 
                throw new NotFoundException(nameof(tennisActivitySlot), request.TennisFieldActivitySlotId);
            tennisActivitySlot.AvailableSlots = request.AvailableSlots;
            tennisActivitySlot.IsActive = request.IsActive;
            await _tennisFieldActivitySlotRepository.UpdateAsync(tennisActivitySlot);
        }
    }
}
