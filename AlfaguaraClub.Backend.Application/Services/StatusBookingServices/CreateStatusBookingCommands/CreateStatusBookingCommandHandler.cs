using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StatusBookingServices.CreateStatusBookingCommands
{
    public class CreateStatusBookingCommandHandler : IRequestHandler<CreateStatusBookingCommand, int>
    {
        private readonly IStatusBookingRepository _statusBookingRepository;
        private IMapper _mapper;
        public CreateStatusBookingCommandHandler(IStatusBookingRepository statusBookingRepository, IMapper mapper)
        {
            _statusBookingRepository = statusBookingRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateStatusBookingCommand request, CancellationToken cancellationToken)
        {
            var newStatusB = _mapper.Map<StatusBooking>(request);
            newStatusB = await _statusBookingRepository.AddAsync(newStatusB);
            return newStatusB.StatusBookingId;
        }
    }
}
