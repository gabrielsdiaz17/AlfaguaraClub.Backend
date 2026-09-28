using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface IMonthlyCouponBookRepository:IRepository<MonthlyCouponBook>
    {
        Task<List<MonthlyCouponBook>> GetCouponBooksByMonthAsync(DateTime month);
        Task<List<Membership>> GetMembershipsWithoutCouponBookAsync(DateTime month);
    }
}
