using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.QuerySpaceActivityCommands
{
    public class GetSpaceActivityQuery: IRequest<SpaceActivityListVm>
    {
        public long SpaceActivityId { get; set; }
    }
}
