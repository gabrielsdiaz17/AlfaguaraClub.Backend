﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingStatusServices.CreateBillingStatusCommands
{
    public class CreateBillingStatusCommand:IRequest<CreateBillingStatusCommandResponse>
    {
        public string Status { get; set; }
        public string? Nomenclature { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Billing Status: Status{Status}";
        }
    }
}
