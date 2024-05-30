using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.QueryBillingCommands
{
    public class GetBillingListByStatusHandler : IRequestHandler<GetBillingListByStatus, List<BillingListVm>>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;
        public GetBillingListByStatusHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<List<BillingListVm>> Handle(GetBillingListByStatus request, CancellationToken cancellationToken)
        {
            var billingsByStatus = await _billingRepository.GetBillingsByStatusBilling(request.BillingStatusId);
            return _mapper.Map<List<BillingListVm>>(billingsByStatus);
        }
    }
}
