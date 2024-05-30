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
    public class GetBillingListQueryHandler : IRequestHandler<GetBillingListQuery, List<BillingListVm>>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;
        public GetBillingListQueryHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<List<BillingListVm>> Handle(GetBillingListQuery request, CancellationToken cancellationToken)
        {
            var billings = await _billingRepository.GetBillings();
            return _mapper.Map<List<BillingListVm>>(billings);
        }
    }
}
