using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.SpaceActivitySlotsCommands.QuerySlotCommands
{
    public class SpaceActivitySlotVm
    {
        public long SpaceActivitySlotId { get; set; }
        public long SpaceActivityId { get; set; }
        public int RailNumber { get; set; }
        public int MaxQuorum { get; set; }
        public int CurrentQuorum { get; set; }
        public bool IsAvailable => CurrentQuorum < MaxQuorum;
        public bool IsActive { get; set; }

    }
}
