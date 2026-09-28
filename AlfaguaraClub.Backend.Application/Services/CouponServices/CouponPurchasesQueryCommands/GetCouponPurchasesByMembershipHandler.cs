using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CouponPurchasesQueryCommands
{
    public class GetCouponPurchasesByMembershipHandler : IRequestHandler<GetCouponPurchasesByMembershipQuery, List<CouponPurchaseVm>>
    {
        private readonly ICouponPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public GetCouponPurchasesByMembershipHandler(ICouponPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<List<CouponPurchaseVm>> Handle(GetCouponPurchasesByMembershipQuery request, CancellationToken cancellationToken)
        {
            var purchases = await _purchaseRepository.GetByMembershipAndMonth(request.MembershipId, request.Month);
            return _mapper.Map<List<CouponPurchaseVm>>(purchases);            
        }
    }
}
