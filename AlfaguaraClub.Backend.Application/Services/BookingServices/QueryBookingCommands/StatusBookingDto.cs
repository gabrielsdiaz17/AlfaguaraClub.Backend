using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.QueryBookingCommands
{
    public class StatusBookingDto
    {
        public int StatusBookingId { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }

    }
}
