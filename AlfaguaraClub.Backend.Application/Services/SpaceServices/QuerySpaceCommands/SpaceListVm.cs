using AlfaguaraClub.Backend.Application.Services.SiteServices.QuerySiteCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.QuerySpaceCommands
{
    public class SpaceListVm
    {
        public long SpaceId { get; set; }
        public string SpaceName { get; set; }

        public string SpaceDescription { get; set; }
        public long CostCenterId { get; set; }
        public CostCenterDto Costcenter { get; set; }
        public string? VideoLink { get; set; }
        public bool IsActive { get; set; }
        public ICollection<PictureDto> Pictures { get; set; }
        public ICollection<SpaceActivityDto> SpaceActivities { get; set; }


    }
}
