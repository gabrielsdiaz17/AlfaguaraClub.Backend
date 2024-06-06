using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SiteServices.CreateSiteCommands
{
    public class CreateSiteCommand: IRequest<CreateSiteCommandResponse>
    {
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string? SiteLocationMap { get; set; }
        public long CompanyId { get; set; }
        public override string ToString()
        {
            return $"Site Name: {SiteName}; Address: {SiteAddress}; ";
        }

    }
}
