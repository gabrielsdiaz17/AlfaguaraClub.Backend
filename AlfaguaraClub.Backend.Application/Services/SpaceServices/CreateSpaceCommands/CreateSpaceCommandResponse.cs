using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.CreateSpaceCommands
{
    public class CreateSpaceCommandResponse:BaseResponse
    {
        public CreateSpaceCommandResponse():base()
        {
            
        }
        public long SpaceId { get; set; }
    }
}
