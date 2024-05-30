using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingStatusServices.QueryBillingStatusCommands
{
    public class GetBillingStatusListQueryHandler : IRequestHandler<GetBillingStatusListQuery, List<BillingStatusListVm>>
    {
        private readonly IBillingStatusRepository _billingStatusRepository;
        private readonly IMapper _mapper;
        public GetBillingStatusListQueryHandler(IBillingStatusRepository billingStatusRepository, IMapper mapper)
        {
            _billingStatusRepository = billingStatusRepository;
            _mapper = mapper;
        }

        public async Task<List<BillingStatusListVm>> Handle(GetBillingStatusListQuery request, CancellationToken cancellationToken)
        {
            var billingStatus = await _billingStatusRepository.GetBillingStatusList();
            return _mapper.Map<List<BillingStatusListVm>>(billingStatus);
        }
    }
}
