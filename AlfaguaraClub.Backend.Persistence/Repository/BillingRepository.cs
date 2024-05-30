using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class BillingRepository : BaseRepository<Billing>, IBillingRepository
    {
        public BillingRepository(IRepository<Billing> repository) : base(repository)
        {
        }

        public async Task<Billing> GetBillingById(long id)
        {
            var billing = await QueryNoTracking().Where(bill=> bill.BillingId == id).FirstOrDefaultAsync();
            return billing;
        }

        public async Task<List<Billing>> GetBillings()
        {
            var billings = await QueryNoTracking().Where(bill=>bill.IsActive)
                                                  .OrderByDescending(bill=>bill.BillingId).ToListAsync();
            return billings;
        }

        public async Task<List<Billing>> GetBillingsByDate(DateTimeOffset date)
        {
            var billingsByDate = await QueryNoTracking().Where(bill=> bill.BillingDate == date && bill.IsActive)
                                                        .OrderByDescending(bill => bill.BillingId).ToListAsync();
            return billingsByDate;
        }

        public async Task<List<Billing>> GetBillingsByDateAndStatus(DateTimeOffset date, int billingStatus)
        {
            var billings = await QueryNoTracking().Where(bill=> bill.BillingDate == date && bill.BillingStatusId == billingStatus)
                                                  .OrderByDescending(bill => bill.BillingId).ToListAsync();
            return billings;
        }

        public async Task<List<Billing>> GetBillingsByStatusBilling(int billingStatus)
        {
            var billingByStatus = await QueryNoTracking().Where(bill=>bill.BillingStatusId == billingStatus)
                                                         .OrderByDescending(bill => bill.BillingId).ToListAsync();
            return billingByStatus;
        }
    }
}
