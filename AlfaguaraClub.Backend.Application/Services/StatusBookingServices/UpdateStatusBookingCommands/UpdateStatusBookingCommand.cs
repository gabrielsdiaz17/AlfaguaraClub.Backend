using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StatusBookingServices.UpdateStatusBookingCommands
{
    public class UpdateStatusBookingCommand:IRequest
    {
        public int StatusBookingId { get; set; }
        public string Status { get; set; }

    }
}
