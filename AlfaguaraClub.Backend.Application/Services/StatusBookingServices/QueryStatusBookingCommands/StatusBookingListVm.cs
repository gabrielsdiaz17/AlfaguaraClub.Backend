using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StatusBookingServices.QueryStatusBookingCommands
{
    public class StatusBookingListVm
    {
        public int StatusBookingId { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }

    }
}
