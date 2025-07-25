﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.UpdateBookingCommands
{
    public class UpdateBookingCommand: IRequest
    {
        public long BookingId { get; set; }
        public long UserId { get; set; }
        public long SpaceActivityId { get; set; }
        public long? MembershipId { get; set; }
        public int StatusBookingId { get; set; }
        public long? SpaceActivitySlotId { get; set; }
        public long? TennisFieldActivitySlotId { get; set; }
        public long? SquashFieldActivitySlotId { get; set; }

        public bool IsActive { get; set; }

    }
}
