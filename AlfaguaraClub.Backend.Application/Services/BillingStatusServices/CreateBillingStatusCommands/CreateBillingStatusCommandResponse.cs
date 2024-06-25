using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingStatusServices.CreateBillingStatusCommands
{
    public class CreateBillingStatusCommandResponse:BaseResponse
    {
        public CreateBillingStatusCommandResponse():base()
        {
            
        }
        public int BillingStatusId { get; set; }
    }
}
