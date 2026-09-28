using AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CouponBookQueryCommands
{
    public class GetUnpaidMembershipsForMonthQuery : IRequest<List<MembershipListVm>>
    {
        public DateTime Month { get; set; }
    }
}
