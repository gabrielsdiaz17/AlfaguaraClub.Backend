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
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string? SiteLocationMap { get; set; }
        public long CompanyId { get; set; }
        public ICollection<PictureDto> Pictures { get; set; }
        public ICollection<SpaceActivityDto> SpaceActivities { get; set; }


    }
}
