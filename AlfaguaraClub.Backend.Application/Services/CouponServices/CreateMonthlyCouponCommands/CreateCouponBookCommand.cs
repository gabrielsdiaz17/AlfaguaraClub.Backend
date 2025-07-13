using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CreateMonthlyCouponCommands
{
    public class CreateCouponBookCommand : IRequest<CreateCouponBookResponse>
    {
        public long MembershipId { get; set; }
        public DateTime Month { get; set; }
        public decimal InitialBalance { get; set; }
    }
}
