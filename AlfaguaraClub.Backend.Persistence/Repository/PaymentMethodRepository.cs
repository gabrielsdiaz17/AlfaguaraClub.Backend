using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class PaymentMethodRepository : BaseRepository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(IRepository<PaymentMethod> repository) : base(repository)
        {
        }

        public async Task<List<PaymentMethod>> GetActivePaymentMethods()
        {
            var paymentMethods = await QueryNoTracking().Where(payment=> payment.IsActive)
                                                        .OrderByDescending(payment=>payment.PaymentMethodId)
                                                        .ToListAsync();
            return paymentMethods;  
        }
    }
}
