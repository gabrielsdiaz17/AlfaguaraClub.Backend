using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface IMembershipRepository: IRepository<Membership>
    {
        Task<List<Membership>> GetAllMemberships();
        Task <Membership> GetMembershipWithUsers(long membershipId);
        Task<Membership> GetMembershipByIdentifier(string uniqueIdentifier);
    }
}
