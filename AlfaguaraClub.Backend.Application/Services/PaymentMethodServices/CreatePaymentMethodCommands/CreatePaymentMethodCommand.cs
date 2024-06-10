using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.CreatePaymentMethodCommands
{
    public class CreatePaymentMethodCommand:IRequest<CreatePaymentMethodCommandResponse>
    {
        public string PaymentMethodCode { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Payment Method Code{PaymentMethodCode}; Description{Description}";
        }
    }
}
