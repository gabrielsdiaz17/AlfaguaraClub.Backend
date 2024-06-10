using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.QueryBillingCommands
{
    public class BillingStatusDto
    {
        public int BillingStatusId { get; set; }
        public string Status { get; set; }
        public string? Nomenclature { get; set; }
        public bool IsActive { get; set; }

    }
}
