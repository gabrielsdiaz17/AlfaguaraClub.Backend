using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.CreateSpaceActivityCommands
{
    public class CreateSpaceActivityCommandResponse:BaseResponse
    {
        public CreateSpaceActivityCommandResponse():base()
        {
            
        }
        public long SpaceActivityId { get; set; }

    }
}
