using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class MembershipRepository : BaseRepository<Membership>, IMembershipRepository
    {
        public MembershipRepository(IRepository<Membership> repository) : base(repository)
        {
        }

        public async Task<List<Membership>> GetAllMemberships()
        {
            var memberships = await QueryNoTracking().Where(member=> member.IsActive)
                                    .Include(member=> member.Users)
                                    .OrderByDescending(member=>member.MembershipId)
                                    .ToListAsync();
            return memberships;
        }       

        public async Task<Membership> GetMembershipWithUsers(long membershipId)
        {
            var membership = await QueryNoTracking().Where(member=> member.MembershipId == membershipId)
                                    .Include(member=> member.Users)
                                    .FirstOrDefaultAsync();
            return membership;
        }
        public async Task<Membership> GetMembershipByIdentifier(string uniqueIdentifier)
        {
            var membership = await QueryNoTracking().Where(membership=> membership.UniqueIdentifier == uniqueIdentifier)
                                                    .Include(member=> member.Users)
                                                    .OrderByDescending(member => member.MembershipId)
                                                    .FirstOrDefaultAsync();
            return membership;
        }
    }
}
