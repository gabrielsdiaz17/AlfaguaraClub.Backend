using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ContactRequestServices.CreateContactRequestCommands
{
    public class CreateContactRequestCommandResponse:BaseResponse
    {
        public CreateContactRequestCommandResponse():base()
        {
        }
        public long ContactRequestId { get; set; }

    }
}
