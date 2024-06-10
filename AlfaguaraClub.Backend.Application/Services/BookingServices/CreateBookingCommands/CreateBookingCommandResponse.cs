using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.CreateBookingCommands
{
    public class CreateBookingCommandResponse: BaseResponse
    {
        public CreateBookingCommandResponse():base()
        {
            
        }
        public long BookingId { get; set; }

    }
}
