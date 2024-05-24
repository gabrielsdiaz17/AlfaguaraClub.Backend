using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.QuerySpaceActivityCommands
{
    public class GetSpaceActivityBySpaceQuery:IRequest<List<SpaceActivityListVm>>
    {
        public long SpaceId { get; set; }
    }
}
