using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.SpaceActivitySlotsCommands.UpdateSlotCommands
{
    public class UpdateSlotForSwimmingPool: IRequest
    {
        public long SpaceActivitySlotId { get; set; }
        public int CurrentQuorum { get; set; }
    }
}
