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
    public class GetCouponPurchasesByBookIdHandler : IRequestHandler<GetCouponPurchasesByBookIdQuery, List<CouponPurchaseVm>>
    {
        private readonly ICouponPurchaseRepository _purchaseRepo;
        private readonly IMapper _mapper;
        public GetCouponPurchasesByBookIdHandler(ICouponPurchaseRepository purchaseRepo, IMapper mapper)
        {
            _purchaseRepo = purchaseRepo;
            _mapper = mapper;
        }

        public async Task<List<CouponPurchaseVm>> Handle(GetCouponPurchasesByBookIdQuery request, CancellationToken cancellationToken)
        {
            var purchases = await _purchaseRepo.GetByCouponBookIdWithDetails(request.MonthlyCouponBookId);
            return _mapper.Map<List<CouponPurchaseVm>>(purchases);
        }
    }
}
