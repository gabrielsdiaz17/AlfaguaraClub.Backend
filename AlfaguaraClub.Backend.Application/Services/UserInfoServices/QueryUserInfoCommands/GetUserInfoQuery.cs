using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserInfoServices.QueryUserInfoCommands
{
    public class GetUserInfoQuery:IRequest<UserInfoVm>
    {
        public string IdentificationNumber { get; set; }        
    }
}
