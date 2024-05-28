using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TypeActivityServices.UpdateTypeActivityCommands
{
    public class UpdateTypeActivityCommand: IRequest
    {
        public int TypeActivityId { get; set; }
        public string TypeActivityName { get; set; }

    }
}
