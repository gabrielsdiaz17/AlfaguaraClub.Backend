using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.CreateBookingCommands
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, long>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public CreateBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = _mapper.Map<Booking>(request);
            booking = await _bookingRepository.AddAsync(booking);
            return booking.BookingId;
        }
    }
}
