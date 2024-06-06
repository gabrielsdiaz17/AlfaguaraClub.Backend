using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserServices.CreateUserCommands
{
    public class CreateUserCommandResponse:BaseResponse
    {
        public CreateUserCommandResponse():base()
        {
            
        }
        public long UserId { get; set; }

    }
}
