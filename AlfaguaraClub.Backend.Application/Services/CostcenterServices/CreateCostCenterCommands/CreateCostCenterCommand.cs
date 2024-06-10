using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CostcenterServices.CreateCostCenterCommands
{
    public class CreateCostCenterCommand: IRequest<CreateCostCenterCommandResponse>        
    {
        public string CostCenterCode { get; set; }
        public string CostCenterName { get; set; }
        public long SiteId { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Cost Center: {CostCenterCode}; Name:{CostCenterName}; Site:{SiteId}";
        }
    }
}
