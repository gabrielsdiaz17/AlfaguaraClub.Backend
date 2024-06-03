using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingDetailServices.CreateBillingDetailCommands
{
    public class CreateBillingDetailCommandHandler : IRequestHandler<CreateBillingDetailCommand, long>
    {
        private readonly IBillingDetailRepository _billingDetailRepository;
        private readonly IMapper _mapper;
        public CreateBillingDetailCommandHandler(IBillingDetailRepository billingDetailRepository, IMapper mapper)
        {
            _billingDetailRepository = billingDetailRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateBillingDetailCommand request, CancellationToken cancellationToken)
        {
           var newBillingDetail = _mapper.Map<BillingDetail>(request);
           newBillingDetail = await _billingDetailRepository.AddAsync(newBillingDetail);
            return newBillingDetail.BillingDetailId;
        }
    }
}
