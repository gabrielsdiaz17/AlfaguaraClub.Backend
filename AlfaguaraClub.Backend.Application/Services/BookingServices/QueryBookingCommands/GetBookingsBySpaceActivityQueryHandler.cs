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
    public class GetBookingsBySpaceActivityQueryHandler : IRequestHandler<GetBookingsBySpaceActivityQuery, List<BookingListVm>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public GetBookingsBySpaceActivityQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }
        public async Task<List<BookingListVm>> Handle(GetBookingsBySpaceActivityQuery request, CancellationToken cancellationToken)
        {
            var bookingsBySpaceActivity = await _bookingRepository.GetBookingsBySpaceActivityId(request.SpaceActivityId);
            return _mapper.Map<List<BookingListVm>>(bookingsBySpaceActivity);   
        }
    }
}
