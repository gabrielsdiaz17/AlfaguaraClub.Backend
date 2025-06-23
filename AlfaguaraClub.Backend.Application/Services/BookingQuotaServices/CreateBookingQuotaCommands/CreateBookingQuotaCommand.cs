using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingQuotaServices.CreateBookingQuotaCommands
{
    public class CreateBookingQuotaCommand: IRequest<CreateBookingQuotaCommandResponse>
    {
        public long BookingId { get; set; }
        public List<long> UserIds { get; set; }
        public bool IsActive { get; set; }

    }
}
