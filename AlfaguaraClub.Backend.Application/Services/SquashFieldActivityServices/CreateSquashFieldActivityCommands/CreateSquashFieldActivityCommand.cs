using AlfaguaraClub.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SquashFieldActivityServices.CreateSquashFieldActivityCommands
{
    public class CreateSquashFieldActivityCommand: IRequest<CreateSquashFieldActivityCommandResponse>
    {
        public List<CreateSquashSpaceActivitySlot> CreateSquashSpaceActivitySlotList { get; set; }

    }
    public class CreateSquashSpaceActivitySlot
    {
        public long SpaceActivityId { get; set; }
        public int FieldNumber { get; set; }
        public int AvailableSlots { get; set; }
        public bool IsActive { get; set; }
    }
}
