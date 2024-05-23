using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SiteServices.QuerySiteCommands
{
    public class SiteListVm
    {
        public long SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string? SiteLocationMap { get; set; }
        public long CompanyId { get; set; }
        public ICollection<CostCenterDto>? CostCenters { get; set; }
    }
}
