using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.RoleServices.CreateRoleCommands
{
    public class CreateRoleCommand:IRequest<int>
    {
        public string RoleName { get; set; }
        public override string ToString()
        {
            return $"Role {RoleName}";
        }
    }
}
