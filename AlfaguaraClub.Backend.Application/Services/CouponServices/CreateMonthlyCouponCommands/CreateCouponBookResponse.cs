using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CreateMonthlyCouponCommands
{
    public class CreateCouponBookResponse:BaseResponse
    {
        public CreateCouponBookResponse():base()
        {
            
        }
        public long MonthlyCouponBookId { get; set; }
    }
}
