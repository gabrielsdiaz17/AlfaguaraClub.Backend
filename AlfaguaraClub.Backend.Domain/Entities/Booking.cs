﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlfaguaraClub.Backend.Domain.Entities;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class Booking: AuditableEntity
    {
        [Key]
        public long BookingId { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("SpaceActivity")]
        public long SpaceActivityId { get; set; }
        public SpaceActivity SpaceActivity { get; set; }

        [ForeignKey("Membership")]
        public long? MembershipId { get; set; }
        public Membership Membership { get; set; }

        [ForeignKey("StatusBooking")]
        public int StatusBookingId { get; set; }
        public StatusBooking StatusBooking { get; set; }

        [ForeignKey("SpaceActivitySlot")]
        public long? SpaceActivitySlotId { get; set; }
        public SpaceActivitySlot SpaceActivitySlot { get; set; }

        [ForeignKey("TennisFieldActivitySlot")]
        public long? TennisFieldActivitySlotId { get; set; }
        public TennisFieldActivitySlot TennisFieldActivitySlot { get; set; }
        
        [ForeignKey("SquashFieldActivitySlot")]
        public long? SquashFieldActivitySlotId { get; set; }
        public SquashFieldActivitySlot SquashFieldActivitySlot { get; set; }
        public bool IsActive { get; set; }
        public Billing Billing { get; set; }
        public ICollection<BookingQuota> BookingQuotas { get; set; }

    }
}
