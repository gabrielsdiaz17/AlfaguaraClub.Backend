using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.CreateSpaceActivityCommands
{
    public class CreateMassiveSpaceActivityCommandResponse:BaseResponse
    {
        public CreateMassiveSpaceActivityCommandResponse():base()
        {
            
        }
        public bool SavedRecords { get; set; }
        public List<long> SpaceActivityIds { get; set; }

    }
}
