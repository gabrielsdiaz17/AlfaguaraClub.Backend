using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class BookingQuota : AuditableEntity
    {
        [Key]
        public long BookingQuotaId { get; set; }

        [ForeignKey("Booking")]
        public long BookingId { get; set; }
        public Booking Booking { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        public bool IsActive { get; set; }
    }
}
