using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class CouponPurchaseRepository : BaseRepository<CouponPurchase>, ICouponPurchaseRepository
    {
        public CouponPurchaseRepository(IRepository<CouponPurchase> repository) : base(repository)
        {
        }

        public async Task<List<CouponPurchase>> GetByCouponBookIdWithDetails(long couponBookId)
        {
            return await QueryNoTracking().Include(cp => cp.Product)
                                            .Include(cp => cp.CostCenter)
                                            .Include(cp => cp.User)
                                            .Where(cp => cp.MonthlyCouponBookId == couponBookId)
                                            .ToListAsync();
            
        }

        public async Task<List<CouponPurchase>> GetByMembershipAndMonth(long membershipId, DateTime month)
        {
            return await QueryNoTracking().Include(cp => cp.Product)
                                    .Include(cp => cp.CostCenter)
                                    .Include(cp => cp.User)
                                    .Include(cp => cp.MonthlyCouponBook)
                                    .Where(cp =>
                                        cp.MonthlyCouponBook.MembershipId == membershipId &&
                                        cp.MonthlyCouponBook.Month.Year == month.Year &&
                                        cp.MonthlyCouponBook.Month.Month == month.Month)
                                    .ToListAsync();
        }
    }
}
