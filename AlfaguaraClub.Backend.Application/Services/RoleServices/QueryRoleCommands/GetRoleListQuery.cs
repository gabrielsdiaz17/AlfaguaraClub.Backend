using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.RoleServices.QueryRoleCommands
{
    public class GetRoleListQuery: IRequest<List<RoleListVm>>
    {
    }
}
