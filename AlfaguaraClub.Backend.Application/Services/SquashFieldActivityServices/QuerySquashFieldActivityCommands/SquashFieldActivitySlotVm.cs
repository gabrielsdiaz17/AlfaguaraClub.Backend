using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SquashFieldActivityServices.QuerySquashFieldActivityCommands
{
    public class SquashFieldActivitySlotVm
    {
        public long SquashFieldActivitySlotId { get; set; }
        public long SpaceActivityId { get; set; }
        public int FieldNumber { get; set; }
        public int AvailableSlots { get; set; }
        public bool IsActive { get; set; }
    }
}
