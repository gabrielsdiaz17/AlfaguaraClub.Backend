using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserServices.QueryUserCommands
{
    public class GetUserLoginQuery:IRequest<UserListVm>
    {
        public string? UniqueIdentifier { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
    }
}
