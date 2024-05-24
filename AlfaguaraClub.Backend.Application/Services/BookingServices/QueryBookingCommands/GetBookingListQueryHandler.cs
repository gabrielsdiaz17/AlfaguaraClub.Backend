using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Services.SiteServices.QuerySiteCommands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.QueryBookingCommands
{
    public class GetBookingListQueryHandler : IRequestHandler<GetBookingListQuery, List<BookingListVm>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public GetBookingListQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<List<BookingListVm>> Handle(GetBookingListQuery request, CancellationToken cancellationToken)
        {
            var bookings = await _bookingRepository.GetBookings();
            return _mapper.Map<List<BookingListVm>>(bookings);
        }
    }
}
