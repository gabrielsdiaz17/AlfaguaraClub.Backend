using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.SpaceActivitySlotsCommands.CreateSlotCommands
{
    public class CreateSlotForSwimmingPool: IRequest<CreateSlotForSwimmingPoolResponse>
    {
        public long SpaceActivityId { get; set; }
        public int RailCount  { get; set; }
        public int MaxQuorum { get; set; }
        public int CurrentQuorum { get; set; }
    }
}
