using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StatusBookingServices.UpdateStatusBookingCommands
{
    public class UpdateStatusBookingCommandHandler : IRequestHandler<UpdateStatusBookingCommand>
    {
        private readonly IStatusBookingRepository _statusBookingRepository;
        private readonly IMapper _mapper;
        public UpdateStatusBookingCommandHandler(IStatusBookingRepository statusBookingRepository, IMapper mapper)
        {
            _statusBookingRepository = statusBookingRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateStatusBookingCommand request, CancellationToken cancellationToken)
        {
            var stBookingToUpdate = await _statusBookingRepository.GetByIdAsync(request.StatusBookingId);
            if (stBookingToUpdate == null) { }
            _mapper.Map(request, stBookingToUpdate, typeof(UpdateStatusBookingCommand), typeof(StatusBooking));
            await _statusBookingRepository.UpdateAsync(stBookingToUpdate);
        }
    }
}
