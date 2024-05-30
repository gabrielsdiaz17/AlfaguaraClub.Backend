using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.UpdateBillingCommands
{
    public class UpdateBillingCommandHandler : IRequestHandler<UpdateBillingCommand>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;
        public UpdateBillingCommandHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBillingCommand request, CancellationToken cancellationToken)
        {
            var billingToUpdate = await _billingRepository.GetByIdAsync(request.BillingId);
            if (billingToUpdate == null) { }
            _mapper.Map(request, billingToUpdate, typeof(UpdateBillingCommand), typeof(Billing));
            await _billingRepository.UpdateAsync(billingToUpdate);
        }
    }
}
