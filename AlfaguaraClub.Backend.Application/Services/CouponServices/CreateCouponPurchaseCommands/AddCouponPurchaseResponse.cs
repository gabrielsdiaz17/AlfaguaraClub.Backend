using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CreateCouponPurchaseCommands
{
    public class AddCouponPurchaseResponse: BaseResponse
    {
        public AddCouponPurchaseResponse():base()
        {
            
        }
        public long CouponPurchaseId { get; set; }
        public decimal RemainingBalance { get; set; }
    }

}
