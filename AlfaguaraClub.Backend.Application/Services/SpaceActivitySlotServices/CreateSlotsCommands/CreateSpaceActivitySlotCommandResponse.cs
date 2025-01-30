using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivitySlotServices.CreateSlotsCommands
{
    public class CreateSpaceActivitySlotCommandResponse:BaseResponse
    {
        public CreateSpaceActivitySlotCommandResponse():base()
        {
            
        }
        public bool SavedRecords { get; set; }

    }
}
