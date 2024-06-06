using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TypeActivityServices.CreateTypeActivityCommands
{
    public class CreateTypeActivityCommand:IRequest<int>
    {
        public string TypeActivityName { get; set; }
        public override string ToString()
        {
            return $"Type Activity {TypeActivityName}";
        }
    }
}
