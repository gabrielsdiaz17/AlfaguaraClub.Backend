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
    public class GetBookingsByMembershipQueryHandler : IRequestHandler<GetBookingsByMembershipQuery, List<BookingListVm>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public GetBookingsByMembershipQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        public async Task<List<BookingListVm>> Handle(GetBookingsByMembershipQuery request, CancellationToken cancellationToken)
        {
            var bookingsByMembership = await _bookingRepository.GetBookingsByMembership(request.MembershipId);
            return _mapper.Map<List<BookingListVm>>(bookingsByMembership);
        }
    }
}
