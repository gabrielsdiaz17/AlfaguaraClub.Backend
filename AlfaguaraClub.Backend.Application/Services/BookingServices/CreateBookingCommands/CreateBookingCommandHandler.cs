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
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, CreateBookingCommandResponse>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public CreateBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<CreateBookingCommandResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var createBookingCommandResponse = new CreateBookingCommandResponse();
            var booking = _mapper.Map<Booking>(request);
            var validator = new CreateBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count >0 )
            {
                createBookingCommandResponse.Success = false;
                createBookingCommandResponse.ValidationErrors = new List<string>();
                foreach( var error in validationResult.Errors )
                {
                    createBookingCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createBookingCommandResponse.Success)
            {
                booking = await _bookingRepository.AddAsync(booking);
                createBookingCommandResponse.BookingId = booking.BookingId;
            }
            return createBookingCommandResponse;
        }
    }
}
