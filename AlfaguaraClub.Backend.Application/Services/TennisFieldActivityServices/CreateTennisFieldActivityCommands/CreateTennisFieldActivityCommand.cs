using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TennisFieldActivityServices.CreateTennisFieldActivityCommands
{
    public class CreateTennisFieldActivityCommand:IRequest<CreateTennisFieldActivityCommandResponse>
    {
        public List<CreateTennisSpaceActivitySlot> CreateTennisSpaceActivitySlotList { get; set; }
    }
    public class CreateTennisSpaceActivitySlot
    {
        public long SpaceActivityId { get; set; }
        public int FieldNumber { get; set; }
        public int AvailableSlots { get; set; }
        public bool IsActive { get; set; }
    }
}
