using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IRepository<User> repository) : base(repository)
        {
        }

        public async Task<List<User>> GetAllUsersWithMembership()
        {
            var users = await QueryNoTracking().Where(us=> us.IsActive)
                              .Include(us=>us.Membership)
                              .Include(us=>us.Role)
                              .OrderByDescending(us=>us.UserId)
                              .ToListAsync();
            return users;
        }
        public async Task<User> GetUserWithMembership(long userId)
        {
            var user = await QueryNoTracking().Where(us => us.UserId == userId)
                             .Include(us => us.Membership)
                             .Include(us => us.Role)
                             .FirstOrDefaultAsync();
            return user;
        }
        public async Task<User> GetUserLogin(string email, string password)
        {
            var userLogin = await QueryNoTracking().Where(us=> us.Email == email &&  us.Password == password)
                                                   .Include(us => us.Role)
                                                   .Include(us => us.Membership)
                                                   .FirstOrDefaultAsync();
            return userLogin;
        }
    }
}
