using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SiteServices.UpdateCompanyCommands
{
    public class UpdateSiteCommand: IRequest
    {
        public long SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string? SiteLocationMap { get; set; }
        public long CompanyId { get; set; }
    }
}
