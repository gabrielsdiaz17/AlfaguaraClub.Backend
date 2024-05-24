using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllUsersWithMembership();
        Task<User> GetUserWithMembership(long userId);
        Task<User> GetUserLogin(string email, string password);

    }
}
