using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.CreatePaymentMethodCommands
{
    public class CreatePaymentMethodCommandResponse:BaseResponse
    {
        public CreatePaymentMethodCommandResponse()
        {
            
        }
        public int PaymentMethodId { get; set; }

    }
}
