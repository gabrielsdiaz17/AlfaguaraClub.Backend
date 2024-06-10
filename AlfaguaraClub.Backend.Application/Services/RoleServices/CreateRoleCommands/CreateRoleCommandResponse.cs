using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.RoleServices.CreateRoleCommands
{
    public class CreateRoleCommandResponse: BaseResponse
    {
        public CreateRoleCommandResponse():base()
        {
            
        }
        public int RoleId { get; set; }

    }
}
