using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.QueryBookingCommands
{
    public class GetBookingByBookingQueryHandler : IRequestHandler<GetBookingByBookingQuery, BookingListVm>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public GetBookingByBookingQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<BookingListVm> Handle(GetBookingByBookingQuery request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetBookingDetailByBookingId(request.BookingId);
            return _mapper.Map<BookingListVm>(booking);
        }
    }
}
