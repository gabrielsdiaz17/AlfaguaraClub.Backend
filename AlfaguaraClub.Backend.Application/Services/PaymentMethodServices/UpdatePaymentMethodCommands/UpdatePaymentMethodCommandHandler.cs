using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.UpdatePaymentMethodCommands
{
    public class UpdatePaymentMethodCommandHandler : IRequestHandler<UpdatePaymentMethodCommand>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;
        public UpdatePaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var paymentMethodToUpdate = await _paymentMethodRepository.GetByIdAsync(request.PaymentMethodId);
            if (paymentMethodToUpdate == null) { }
            _mapper.Map(request, paymentMethodToUpdate, typeof(UpdatePaymentMethodCommand), typeof(PaymentMethod));
            await _paymentMethodRepository.UpdateAsync(paymentMethodToUpdate);
        }
    }
}
