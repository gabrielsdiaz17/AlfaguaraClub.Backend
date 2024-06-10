using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CostcenterServices.UpdateCostCenterCommands
{
    public class UpdateCostCenterCommand:IRequest
    {
        public long CostCenterId { get; set; }
        public string CostCenterCode { get; set; }
        public string CostCenterName { get; set; }
        public long SiteId { get; set; }
        public bool IsActive { get; set; }

    }
}
