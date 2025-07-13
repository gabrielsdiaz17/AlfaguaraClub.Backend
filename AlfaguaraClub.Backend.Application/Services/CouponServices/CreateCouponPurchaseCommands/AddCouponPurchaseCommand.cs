using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CreateCouponPurchaseCommands
{
    public class AddCouponPurchaseCommand : IRequest<AddCouponPurchaseResponse>
    {
        public long MonthlyCouponBookId { get; set; }

        public List<ProductPurchaseDto> Purchases { get; set; } = new();
    }
}
