using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserServices.QueryUserCommands
{
    public  class GetUserLoginQueryCommandResponse:BaseResponse
    {
        public GetUserLoginQueryCommandResponse():base()
        {
            
        }
        public UserListVm User { get; set; }
        public string token { get; set; }
    }
}
