using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.SpaceActivitySlotsCommands.CreateSlotCommands
{
    public class CreateSlotForSwimmingPoolResponse: BaseResponse
    {
        public CreateSlotForSwimmingPoolResponse():base()
        {
        }
        public bool SavedRecords { get; set; }


    }
}
