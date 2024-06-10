using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingDetailServices.CreateBillingDetailCommands
{
    public class CreateBillingDetailCommandResponse:BaseResponse
    {
        public CreateBillingDetailCommandResponse():base()
        {
            
        }
        public long BillingDetailId { get; set; }

    }
}
