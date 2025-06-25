using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.CreateBookingCommands
{
    public class CreateBookingCommand:IRequest<CreateBookingCommandResponse>
    {
        public long UserId { get; set; }
        public long SpaceActivityId { get; set; }
        public long? MembershipId { get; set; }
        public int StatusBookingId { get; set; }
        public long? SpaceActivitySlotId { get; set; }
        public long? TennisFieldActivitySlotId { get; set; }
        public long? SquashFieldActivitySlotId { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $" Booking Created User: {UserId}; Space:{SpaceActivityId}; Status:{StatusBookingId}";
        }
    }
}
