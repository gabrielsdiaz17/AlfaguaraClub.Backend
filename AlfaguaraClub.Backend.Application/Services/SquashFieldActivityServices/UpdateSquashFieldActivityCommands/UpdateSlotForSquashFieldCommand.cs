using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SquashFieldActivityServices.UpdateSquashFieldActivityCommands
{
    public class UpdateSlotForSquashFieldCommand: IRequest
    {
        public long SquashFieldActivitySlotId { get; set; }
        public int AvailableSlots { get; set; }
        public bool IsActive { get; set; }

    }
}
