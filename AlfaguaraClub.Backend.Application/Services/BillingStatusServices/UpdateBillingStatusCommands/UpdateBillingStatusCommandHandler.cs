using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingStatusServices.UpdateBillingStatusCommands
{
    public class UpdateBillingStatusCommandHandler : IRequestHandler<UpdateBillingStatusCommand>
    {
        private readonly IBillingStatusRepository _billingStatusRepository;
        private readonly IMapper _mapper;
        public UpdateBillingStatusCommandHandler(IBillingStatusRepository billingStatusRepository, IMapper mapper)
        {
            _billingStatusRepository = billingStatusRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBillingStatusCommand request, CancellationToken cancellationToken)
        {
            var billingStatusToUpdate = await _billingStatusRepository.GetByIdAsync(request.BillingStatusId);
            if (billingStatusToUpdate == null) { }
            _mapper.Map(request, billingStatusToUpdate, typeof(UpdateBillingStatusCommand), typeof(BillingStatus));
            await _billingStatusRepository.UpdateAsync(billingStatusToUpdate);
        }
    }
}
