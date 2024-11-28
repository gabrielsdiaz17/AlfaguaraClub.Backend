using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.DeleteSpaceActivityCommands
{
    public class DeleteSpaceActivityCommand: IRequest        
    {
        public DateTime ActivityDate { get; set; }
    }
}
