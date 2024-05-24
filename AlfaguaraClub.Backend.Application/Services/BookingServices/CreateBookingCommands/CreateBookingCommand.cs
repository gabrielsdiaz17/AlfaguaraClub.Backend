using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.CreateBookingCommands
{
    public class CreateBookingCommand:IRequest<long>
    {
        public long UserId { get; set; }
        public long SpaceActivityId { get; set; }
        public long? MembershipId { get; set; }
        public int StatusBookingId { get; set; }

    }
}
