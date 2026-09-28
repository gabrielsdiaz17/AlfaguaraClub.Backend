using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CouponBookQueryCommands
{
    public class GetUnpaidMembershipsForMonthHandler : IRequestHandler<GetUnpaidMembershipsForMonthQuery, List<MembershipListVm>>
    {
        private readonly IMonthlyCouponBookRepository _monthlyCouponBookRepository;
        private readonly IMapper _mapper;
        public GetUnpaidMembershipsForMonthHandler(IMonthlyCouponBookRepository monthlyCouponBookRepository, IMapper mapper)
        {
            _mapper = mapper;
            _monthlyCouponBookRepository = monthlyCouponBookRepository;
        }
        public async Task<List<MembershipListVm>> Handle(GetUnpaidMembershipsForMonthQuery request, CancellationToken cancellationToken)
        {
            var memberships = await _monthlyCouponBookRepository.GetMembershipsWithoutCouponBookAsync(request.Month);
            return _mapper.Map<List<MembershipListVm>>(memberships);
        }
    }
}
