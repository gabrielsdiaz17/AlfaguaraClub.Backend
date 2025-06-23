using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingQuotaServices.CreateBookingQuotaCommands
{
    public class CreateBookingQuotaCommandHandler : IRequestHandler<CreateBookingQuotaCommand, CreateBookingQuotaCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookingQuotaRepository _bookingQuotaRepository;
        public CreateBookingQuotaCommandHandler(IMapper mapper, IBookingQuotaRepository bookingQuotaRepository)
        {
            _mapper = mapper;
            _bookingQuotaRepository = bookingQuotaRepository;
        }

        public async Task<CreateBookingQuotaCommandResponse> Handle(CreateBookingQuotaCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateBookingQuotaCommandResponse();
            var bookingQuotaList = new List<BookingQuota>();
            foreach (var userId in request.UserIds)
            {
                var bookingQuota = new BookingQuota()
                {
                    BookingId = request.BookingId,
                    UserId = userId,
                    IsActive = request.IsActive
                };
                bookingQuotaList.Add(bookingQuota);
            }
            if (response.Success)
            {
                bookingQuotaList = (List<BookingQuota>)await _bookingQuotaRepository.AddRangeAsync(bookingQuotaList);
                response.BookingQuotaIds = bookingQuotaList.Select(x => x.BookingId).ToList();
                response.SavedRecords = true;
            }            
            return response;
        }
    }
}
