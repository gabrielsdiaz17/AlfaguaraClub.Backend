using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SiteServices.CreateSiteCommands
{
    public class CreateSiteCommandResponse:BaseResponse
    {
        public CreateSiteCommandResponse():base()
        {
            
        }
        public long SiteId { get; set; }
    }
}
