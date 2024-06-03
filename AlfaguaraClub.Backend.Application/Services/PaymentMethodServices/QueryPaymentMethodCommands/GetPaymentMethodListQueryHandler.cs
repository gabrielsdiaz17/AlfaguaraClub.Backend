using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.QueryPaymentMethodCommands
{
    public class GetPaymentMethodListQueryHandler : IRequestHandler<GetPaymentMethodListQuery, List<PaymentMethodListVm>>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;
        public GetPaymentMethodListQueryHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }

        public async Task<List<PaymentMethodListVm>> Handle(GetPaymentMethodListQuery request, CancellationToken cancellationToken)
        {
            var paymentMethodList = await _paymentMethodRepository.GetActivePaymentMethods();
            return _mapper.Map<List<PaymentMethodListVm>>(paymentMethodList);
        }
    }
}
