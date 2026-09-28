using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CouponPurchasesQueryCommands
{
    public class GetCouponPurchasesByMembershipQuery : IRequest<List<CouponPurchaseVm>>
    {
        public long MembershipId { get; set; }
        public DateTime Month { get; set; }
    }
}
