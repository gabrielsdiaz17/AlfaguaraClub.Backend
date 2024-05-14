using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class StatusBooking: AuditableEntity
    {
        public int StatusBookingId { get; set; }
        public string Status { get; set; }
    }
}
