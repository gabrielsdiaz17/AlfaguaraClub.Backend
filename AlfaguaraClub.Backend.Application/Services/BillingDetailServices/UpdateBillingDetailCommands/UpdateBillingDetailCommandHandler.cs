﻿using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Exceptions;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingDetailServices.UpdateBillingDetailCommands
{
    public class UpdateBillingDetailCommandHandler : IRequestHandler<UpdateBillingDetailCommand>
    {
        private readonly IBillingDetailRepository _billingDetailRepository;
        private readonly IMapper _mapper;
        public UpdateBillingDetailCommandHandler(IBillingDetailRepository billingDetailRepository, IMapper mapper)
        {
            _billingDetailRepository = billingDetailRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBillingDetailCommand request, CancellationToken cancellationToken)
        {
            var billingDetailToUpdate = await _billingDetailRepository.GetByIdAsync(request.BillingDetailId);
            if (billingDetailToUpdate == null)
                throw new NotFoundException(nameof(BillingDetail), request.BillingDetailId);
            var validator = new UpdateBillingDetailCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            _mapper.Map(request, billingDetailToUpdate, typeof(UpdateBillingDetailCommand), typeof(BillingDetail));
            await _billingDetailRepository.UpdateAsync(billingDetailToUpdate);
        }
    }
}
