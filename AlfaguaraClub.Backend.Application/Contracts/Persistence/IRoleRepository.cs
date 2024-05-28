using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface IRoleRepository: IRepository<Role>
    {
        Task<List<Role>> GetRolesWithUsers();
        Task<List<Role>> GetUsersByRoleId(int roleId);
    }
}
