﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.QueryPaymentMethodCommands
{
    public class PaymentMethodListVm
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethodCode { get; set; }
        public string Description { get; set; }
    }
}
