using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SquashFieldActivityServices.QuerySquashFieldActivityCommands
{
    public class QuerySquashFieldActivityCommand: IRequest<List<SquashFieldActivitySlotVm>>
    {
        public long SpaceActivityId { get; set; }

    }
}
