using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TypeActivityServices.CreateTypeActivityCommands
{
    public class CreateTypeActivityCommandResponse:BaseResponse
    {
        public CreateTypeActivityCommandResponse():base()
        {
            
        }
        public int TypeActivityId { get; set; }

    }

}
