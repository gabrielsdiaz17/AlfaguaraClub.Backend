using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.QueryBookingCommands
{
    public class MembershipDto
    {
        public long MembershipId { get; set; }
        public string UniqueIdentifier { get; set; }
        public bool IsActive { get; set; }

    }
}
