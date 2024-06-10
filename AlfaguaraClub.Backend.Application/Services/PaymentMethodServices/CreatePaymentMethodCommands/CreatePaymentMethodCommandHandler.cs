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
    public class CreatePaymentMethodCommandHandler : IRequestHandler<CreatePaymentMethodCommand, CreatePaymentMethodCommandResponse>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;
        public CreatePaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }

        public async Task<CreatePaymentMethodCommandResponse> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var response = new CreatePaymentMethodCommandResponse();
            var newPaymentMethod = _mapper.Map<PaymentMethod>(request);
            var validator = new CreatePaymentMethodCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                newPaymentMethod = await _paymentMethodRepository.AddAsync(newPaymentMethod);
                response.PaymentMethodId = newPaymentMethod.PaymentMethodId;
            }
            return response;
        }
    }
}
