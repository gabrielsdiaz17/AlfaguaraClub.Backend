using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StatusBookingServices.CreateStatusBookingCommands
{
    public class CreateStatusBookingCommandResponse:BaseResponse
    {
        public CreateStatusBookingCommandResponse():base()
        {
            
        }
        public int StatusBookingId { get; set; }

    }
}
