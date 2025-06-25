using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TennisFieldActivityServices.QueryTennisFieldActivityCommands
{
    public class TennisFieldActivitySlotVm
    {
        public long TennisFieldActivitySlotId { get; set; }
        public long SpaceActivityId { get; set; }
        public int FieldNumber { get; set; }
        public int AvailableSlots { get; set; }
        public bool IsActive { get; set; }
    }
}
