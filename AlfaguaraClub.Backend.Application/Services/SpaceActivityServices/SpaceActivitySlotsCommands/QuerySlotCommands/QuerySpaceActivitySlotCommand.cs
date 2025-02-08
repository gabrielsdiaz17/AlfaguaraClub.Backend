using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.SpaceActivitySlotsCommands.QuerySlotCommands
{
    public class QuerySpaceActivitySlotCommand: IRequest<List<SpaceActivitySlotVm>>
    {
        public long SpaceActivityId { get; set; }
    }
}
