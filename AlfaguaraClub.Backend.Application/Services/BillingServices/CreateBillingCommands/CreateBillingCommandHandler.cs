using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.CreateBillingCommands
{
    public class CreateBillingCommandHandler : IRequestHandler<CreateBillingCommand, CreateBillingCommandResponse>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;
        public CreateBillingCommandHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<CreateBillingCommandResponse> Handle(CreateBillingCommand request, CancellationToken cancellationToken)
        {
            var createBillingCommandResponse = new CreateBillingCommandResponse();
            var billingToSave = _mapper.Map<Billing>(request);
            var validator = new CreateBillingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Count >0)
            {
                createBillingCommandResponse.Success = false;
                createBillingCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    createBillingCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createBillingCommandResponse.Success)
            {
                billingToSave = await _billingRepository.AddAsync(billingToSave);
                createBillingCommandResponse.BillingId = billingToSave.BillingId;
                createBillingCommandResponse.BillingConsecutive = billingToSave.BillingConsecutive;
            }
            
            return createBillingCommandResponse;
        }
    }
}
