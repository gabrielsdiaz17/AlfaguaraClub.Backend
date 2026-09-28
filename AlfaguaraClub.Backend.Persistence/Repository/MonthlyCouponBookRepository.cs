using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class MonthlyCouponBookRepository : BaseRepository<MonthlyCouponBook>, IMonthlyCouponBookRepository
    {
        private readonly IMembershipRepository _membershipRepository;
        public MonthlyCouponBookRepository(IRepository<MonthlyCouponBook> repository, IMembershipRepository membershipRepository) : base(repository)
        {
            _membershipRepository = membershipRepository;
        }

        public async Task<List<MonthlyCouponBook>> GetCouponBooksByMonthAsync(DateTime month)
        {
            return await QueryNoTracking()
                            .Where(cb => cb.Month.Year == month.Year && cb.Month.Month == month.Month && cb.IsActive)
                            .Select(cb => new MonthlyCouponBook
                            {
                                MonthlyCouponBookId = cb.MonthlyCouponBookId,
                                MembershipId = cb.MembershipId,
                                Membership = new Membership
                                {
                                    MembershipId = cb.Membership.MembershipId,
                                    UniqueIdentifier = cb.Membership.UniqueIdentifier,
                                    IsActive = cb.Membership.IsActive,
                                    Users = cb.Membership.Users.Where(u => u.IsActive).ToList()
                                },
                                Month = cb.Month,
                                InitialBalance = cb.InitialBalance,
                                CurrentBalance = cb.CurrentBalance,
                                IsActive = cb.IsActive,
                                
                            }).ToListAsync();
        }

        public async Task<List<Membership>> GetMembershipsWithoutCouponBookAsync(DateTime month)
        {
            var paidMembershipIds = await QueryNoTracking()
                                        .Where(cb => cb.Month.Year == month.Year && cb.Month.Month == month.Month && cb.IsActive)
                                        .Select(cb => cb.MembershipId)
                                        .ToListAsync();
            var memberships = await _membershipRepository.GetAllMemberships();
            return memberships.Where(m => m.IsActive && !paidMembershipIds.Contains(m.MembershipId)).ToList();

        }
    }
}
