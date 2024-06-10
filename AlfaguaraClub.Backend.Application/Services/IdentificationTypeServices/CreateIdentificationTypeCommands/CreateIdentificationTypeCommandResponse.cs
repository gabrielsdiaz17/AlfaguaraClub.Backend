using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.CreateIdentificationTypeCommands
{
    public class CreateIdentificationTypeCommandResponse:BaseResponse
    {
        public CreateIdentificationTypeCommandResponse():base()
        {
            
        }
        public int IdendificationTypeId { get; set; }

    }
}
