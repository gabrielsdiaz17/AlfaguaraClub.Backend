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
    public class GetBillingQueryHandler : IRequestHandler<GetBillingQuery, BillingListVm>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;
        public GetBillingQueryHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<BillingListVm> Handle(GetBillingQuery request, CancellationToken cancellationToken)
        {
            var billing = await _billingRepository.GetBillingById(request.BillingId);
            return _mapper.Map<BillingListVm>(billing);
        }
    }
}
