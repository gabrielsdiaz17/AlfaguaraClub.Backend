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
    public class GetBillingListDateBydateHandler : IRequestHandler<GetBillingListDateByDate, List<BillingListVm>>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;
        public GetBillingListDateBydateHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<List<BillingListVm>> Handle(GetBillingListDateByDate request, CancellationToken cancellationToken)
        {
            var billingsByDate = await _billingRepository.GetBillingsByDate(request.Date);
            return _mapper.Map<List<BillingListVm>>(billingsByDate);
        }
    }
}
