using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingDetailServices.QueryBillingDetailCommands
{
    public class GetBillingDetailListQueryHandler : IRequestHandler<GetBillingDetailListQuery, List<BillingDetailListVm>>
    {
        private readonly IBillingDetailRepository _billingDetailRepository;
        private readonly IMapper _mapper;
        public GetBillingDetailListQueryHandler(IBillingDetailRepository billingDetailRepository, IMapper mapper)
        {
            _billingDetailRepository = billingDetailRepository;
            _mapper = mapper;
        }

        public async Task<List<BillingDetailListVm>> Handle(GetBillingDetailListQuery request, CancellationToken cancellationToken)
        {
            var detailBilling = await _billingDetailRepository.GetDetailBilling(request.BillingId);
            return _mapper.Map<List<BillingDetailListVm>>(detailBilling);
        }
    }
}
