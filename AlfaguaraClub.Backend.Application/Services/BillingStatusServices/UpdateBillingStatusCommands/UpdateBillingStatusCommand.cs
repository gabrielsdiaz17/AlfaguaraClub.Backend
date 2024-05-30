using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingStatusServices.UpdateBillingStatusCommands
{
    public class UpdateBillingStatusCommand: IRequest
    {
        public int BillingStatusId { get; set; }
        public string Status { get; set; }
        public string? Nomenclature { get; set; }
    }
}
