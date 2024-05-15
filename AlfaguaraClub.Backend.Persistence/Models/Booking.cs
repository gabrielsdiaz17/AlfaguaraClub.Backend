﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class Booking: AuditableEntity
    {
        [Key]
        public long BookingId { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Activity")]
        public long ActivityId { get; set; }
        public Activity Activity { get; set; }

        [ForeignKey("Membership")]
        public long? MembershipId { get; set; }
        public Membership Membership { get; set; }

        [ForeignKey("StatusBooking")]
        public int StatusBookingId { get; set; }
        public StatusBooking StatusBooking { get; set; }

    }
}
