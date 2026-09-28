using AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CouponBookQueryCommands
{
    public class CouponBookVm
    {
        public long MonthlyCouponBookId { get; set; }
        public long MembershipId { get; set; }
        public MembershipListVm Membership { get; set; }
        public DateTime Month { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
    }
}
