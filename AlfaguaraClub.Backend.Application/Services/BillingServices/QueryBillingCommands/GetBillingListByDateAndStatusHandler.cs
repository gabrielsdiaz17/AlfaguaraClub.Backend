﻿using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.QueryBillingCommands
{
    public class GetBillingListByDateAndStatusHandler : IRequestHandler<GetBillingListByDateAndStatus, List<BillingListVm>>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;
        public GetBillingListByDateAndStatusHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<List<BillingListVm>> Handle(GetBillingListByDateAndStatus request, CancellationToken cancellationToken)
        {
            var billings = await _billingRepository.GetBillingsByDateAndStatus(request.Date, request.BillingStatusId);
            return _mapper.Map<List<BillingListVm>>(billings);
        }
    }
}
