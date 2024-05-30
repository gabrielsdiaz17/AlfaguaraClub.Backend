using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface IBillingRepository: IRepository<Billing>
    {
        Task<List<Billing>> GetBillings();
        Task<Billing> GetBillingById(long id);
        Task<List<Billing>> GetBillingsByStatusBilling(int billingStatus);
        Task<List<Billing>> GetBillingsByDate(DateTimeOffset date);
        Task<List<Billing>> GetBillingsByDateAndStatus(DateTimeOffset date, int billingStatus);
    }
}
