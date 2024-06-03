using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class BillingDetailRepository : BaseRepository<BillingDetail>, IBillingDetailRepository
    {
        public BillingDetailRepository(IRepository<BillingDetail> repository) : base(repository)
        {
        }

        public async Task<IList<BillingDetail>> GetDetailBilling(long billingId)
        {
            var billingDetail = await QueryNoTracking().Where(billing=> billing.BillingId == billingId)
                                                       .Include(billing=> billing.Product)                                                       
                                                       .ToListAsync();
            return billingDetail;
        }
    }
}
