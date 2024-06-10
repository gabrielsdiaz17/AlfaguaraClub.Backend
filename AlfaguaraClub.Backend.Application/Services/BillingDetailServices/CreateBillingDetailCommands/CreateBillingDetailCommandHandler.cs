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
    public class CreateBillingDetailCommandHandler : IRequestHandler<CreateBillingDetailCommand, CreateBillingDetailCommandResponse>
    {
        private readonly IBillingDetailRepository _billingDetailRepository;
        private readonly IMapper _mapper;
        public CreateBillingDetailCommandHandler(IBillingDetailRepository billingDetailRepository, IMapper mapper)
        {
            _billingDetailRepository = billingDetailRepository;
            _mapper = mapper;
        }

        public async Task<CreateBillingDetailCommandResponse> Handle(CreateBillingDetailCommand request, CancellationToken cancellationToken)
        {
            var createBillingDetailCommandResponse = new CreateBillingDetailCommandResponse();
            var newBillingDetail = _mapper.Map<BillingDetail>(request);
            var validator = new CreateBillingDetailCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count >0)
            {
                createBillingDetailCommandResponse.Success = false;
                createBillingDetailCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    createBillingDetailCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if(createBillingDetailCommandResponse.Success)
            {
                newBillingDetail = await _billingDetailRepository.AddAsync(newBillingDetail);
                createBillingDetailCommandResponse.BillingDetailId = newBillingDetail.BillingDetailId;
            }
            
            return createBillingDetailCommandResponse;
        }
    }
}
