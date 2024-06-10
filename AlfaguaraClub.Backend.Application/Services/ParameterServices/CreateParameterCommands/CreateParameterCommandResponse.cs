using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ParameterServices.CreateParameterCommands
{
    public class CreateParameterCommandResponse:BaseResponse
    {
        public CreateParameterCommandResponse():base()
        {
            
        }
        public long ParameterId { get; set; }

    }
}
