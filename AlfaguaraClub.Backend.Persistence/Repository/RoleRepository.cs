using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(IRepository<Role> repository) : base(repository)
        {
        }

        public async Task<List<Role>> GetRolesWithUsers()
        {
            var roles = await QueryNoTracking().Where(role=>role.IsActive).Include(role => role.Users).ToListAsync();
            return roles;
        }

        public async Task<List<Role>> GetUsersByRoleId(int roleId)
        {
            var rolesById = await QueryNoTracking().Where(role=> role.IsActive && role.RoleId == roleId).Include(role=> role.Users).ToListAsync();  
            return rolesById;
        }
    }
}
