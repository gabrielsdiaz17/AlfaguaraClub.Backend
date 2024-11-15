using AlfaguaraClub.Backend.Application.Services.BillingDetailServices.QueryBillingDetailCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CostcenterServices.QueryCostCenterCommands
{
    public class CostCenterListVm
    {
        public long CostCenterId { get; set; }
        public string CostCenterCode { get; set; }
        public string CostCenterName { get; set; }
        public long SiteId { get; set; }
        public SiteDto Site { get; set; }
        public bool IsActive { get; set; }

        public ICollection<SpaceDto> Spaces { get; set; }
        public ICollection<ProductDto> Products { get; set; }

    }
}
