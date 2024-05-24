using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.UpdateSpaceCommands
{
    public class UpdateSpaceCommand:IRequest
    {
        public long SpaceId { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string? SiteLocationMap { get; set; }
        public long CompanyId { get; set; }
    }
}
