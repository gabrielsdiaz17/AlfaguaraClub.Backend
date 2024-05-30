using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class BillingStatusRepository : BaseRepository<BillingStatus>, IBillingStatusRepository
    {
        public BillingStatusRepository(IRepository<BillingStatus> repository) : base(repository)
        {
        }

        public async Task<List<BillingStatus>> GetBillingStatusList()
        {
            var billingStatusList = await QueryNoTracking().Where(billStatus => billStatus.IsActive).ToListAsync();
            return billingStatusList;
        }
    }
}
