using AlfaguaraClub.Backend.Application.Services.UserServices.QueryUserCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Infraestructure
{
    public interface IJWTProvider
    {
        string Generate(UserListVm user);
    }
}
