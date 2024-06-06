using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StatusBookingServices.QueryStatusBookingCommands
{
    public class GetStatusBookingListQueryHandler : IRequestHandler<GetStatusBookingListQuery, List<StatusBookingListVm>>
    {
        private readonly IStatusBookingRepository _statusBookingRepository;
        private readonly IMapper _mapper;
        public GetStatusBookingListQueryHandler(IStatusBookingRepository statusBookingRepository, IMapper mapper)
        {
            _statusBookingRepository = statusBookingRepository;
            _mapper = mapper;
        }

        public async Task<List<StatusBookingListVm>> Handle(GetStatusBookingListQuery request, CancellationToken cancellationToken)
        {
            var statusBookings = await _statusBookingRepository.GetStatusBooking();
            return _mapper.Map<List<StatusBookingListVm>>(statusBookings);
        }
    }
}
