using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserServices.QueryUserCommands
{
    public class GetUserQuery:IRequest<UserListVm>
    {
        public long UserId { get; set; }
    }
}
