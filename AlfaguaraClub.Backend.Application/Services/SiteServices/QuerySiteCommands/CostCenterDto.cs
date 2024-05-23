using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SiteServices.QuerySiteCommands
{
    public class CostCenterDto
    {
        public long CostCenterId { get; set; }
        public string CostCenterCode { get; set; }
        public string CostCenterName { get; set; }
    }
}
