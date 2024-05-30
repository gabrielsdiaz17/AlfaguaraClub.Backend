using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingStatusServices.CreateBillingStatusCommands
{
    public class CreateBillingStatusCommandHandler : IRequestHandler<CreateBillingStatusCommand, int>
    {
        private readonly IBillingStatusRepository _billingStatusRepository;
        private readonly IMapper _mapper;
        public CreateBillingStatusCommandHandler(IBillingStatusRepository billingStatusRepository, IMapper mapper)
        {
            _billingStatusRepository = billingStatusRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBillingStatusCommand request, CancellationToken cancellationToken)
        {
            var newBillingStatus = _mapper.Map<BillingStatus>(request);
            newBillingStatus = await _billingStatusRepository.AddAsync(newBillingStatus);
            return newBillingStatus.BillingStatusId;
        }
    }
}
