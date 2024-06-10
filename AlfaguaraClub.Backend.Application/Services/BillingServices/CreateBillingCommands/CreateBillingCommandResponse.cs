using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.CreateBillingCommands
{
    public class CreateBillingCommandResponse:BaseResponse
    {
        public CreateBillingCommandResponse():base()
        {
            
        }
        public long BillingId { get; set; }
        public string BillingConsecutive { get; set; }

    }
}
