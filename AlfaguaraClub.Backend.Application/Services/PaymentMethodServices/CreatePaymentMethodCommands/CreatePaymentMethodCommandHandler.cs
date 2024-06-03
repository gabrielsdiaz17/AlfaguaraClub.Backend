using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.CreatePaymentMethodCommands
{
    public class CreatePaymentMethodCommandHandler : IRequestHandler<CreatePaymentMethodCommand, int>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;
        public CreatePaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var newPaymentMethod = _mapper.Map<PaymentMethod>(request);
            newPaymentMethod = await _paymentMethodRepository.AddAsync(newPaymentMethod);
            return newPaymentMethod.PaymentMethodId;
        }
    }
}
