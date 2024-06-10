using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.MembershipServices.CreateMembershipCommands
{
    public class CreateMembershipCommandResponse:BaseResponse
    {
        public CreateMembershipCommandResponse():base()
        {
            
        }
        public long MembershipId { get; set; }

    }
}
