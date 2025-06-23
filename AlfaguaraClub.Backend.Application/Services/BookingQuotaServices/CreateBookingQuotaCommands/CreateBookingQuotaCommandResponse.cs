using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingQuotaServices.CreateBookingQuotaCommands
{
    public class CreateBookingQuotaCommandResponse: BaseResponse
    {
        public CreateBookingQuotaCommandResponse(): base()
        {
            
        }
        public bool SavedRecords { get; set; }
        public List<long> BookingQuotaIds { get; set; }
    }
}
