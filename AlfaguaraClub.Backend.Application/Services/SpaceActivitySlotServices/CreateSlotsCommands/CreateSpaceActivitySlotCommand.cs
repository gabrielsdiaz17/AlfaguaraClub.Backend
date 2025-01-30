using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivitySlotServices.CreateSlotsCommands
{
    public class CreateSpaceActivitySlotCommand: IRequest<CreateSpaceActivitySlotCommandResponse>
    {
        public List<CreateSpaceActivitySlot> CreateSpaceActivitySlotList { get; set; }

    }
    public class CreateSpaceActivitySlot
    {
        public long SpaceActivityId { get; set; }
        public int RailNumber { get; set; }
        public int MaxQuorum { get; set; }
    }
}
