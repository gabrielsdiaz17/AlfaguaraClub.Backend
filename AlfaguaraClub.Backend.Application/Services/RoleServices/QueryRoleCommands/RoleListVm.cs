using AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.RoleServices.QueryRoleCommands
{
    public class RoleListVm
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }

        public ICollection<UserDto> Users { get; set; }

    }
}
