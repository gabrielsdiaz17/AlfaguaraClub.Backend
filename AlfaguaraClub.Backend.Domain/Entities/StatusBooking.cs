using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class StatusBooking: AuditableEntity
    {
        public int StatusBookingId { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public bool IsActive { get; set; }

    }
}
