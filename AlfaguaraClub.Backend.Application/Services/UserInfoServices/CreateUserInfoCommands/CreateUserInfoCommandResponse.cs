using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserInfoServices.CreateUserInfoCommands
{
    public class CreateUserInfoCommandResponse:BaseResponse
    {
        public CreateUserInfoCommandResponse():base()
        {
            
        }
        public long UserInfoId { get; set; }
    }
}
