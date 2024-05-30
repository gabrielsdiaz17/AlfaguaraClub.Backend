using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.CreateBillingCommands
{
    public class CreateBillingCommandHandler : IRequestHandler<CreateBillingCommand, long>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;
        public CreateBillingCommandHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateBillingCommand request, CancellationToken cancellationToken)
        {
            var billingToSave = _mapper.Map<Billing>(request);
            billingToSave = await _billingRepository.AddAsync(billingToSave);
            return billingToSave.BillingId;
        }
    }
}
