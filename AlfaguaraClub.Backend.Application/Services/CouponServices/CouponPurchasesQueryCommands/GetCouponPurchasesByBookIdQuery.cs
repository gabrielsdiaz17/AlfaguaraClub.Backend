using AlfaguaraClub.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CouponPurchasesQueryCommands
{
    public class GetCouponPurchasesByBookIdQuery : IRequest<List<CouponPurchaseVm>>
    {
        public long MonthlyCouponBookId { get; set; }
    }
}
