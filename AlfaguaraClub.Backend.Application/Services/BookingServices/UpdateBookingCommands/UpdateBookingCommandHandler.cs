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

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.UpdateBookingCommands
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public UpdateBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {            
            var bookingToUpdate = await _bookingRepository.GetByIdAsync(request.BookingId);
            if (bookingToUpdate == null)
                throw new NotFoundException(nameof(Booking), bookingToUpdate.BookingId);
            var validator = new UpdateBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            _mapper.Map(request, bookingToUpdate ,typeof(UpdateBookingCommand), typeof(Booking));
            await _bookingRepository.UpdateAsync(bookingToUpdate);
        }
    }
}
