using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TaxServices.CreateTaxCommands
{
    public class CreateTaxCommandHandler : IRequestHandler<CreateTaxCommand, CreateTaxCommandResponse>
    {
        private readonly ITaxRepository _taxRepository;
        private readonly IMapper _mapper;
        public CreateTaxCommandHandler(ITaxRepository taxRepository, IMapper mapper)
        {
            _taxRepository = taxRepository;
            _mapper = mapper;
        }

        public async Task<CreateTaxCommandResponse> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateTaxCommandResponse();
            var newTax = _mapper.Map<Tax>(request);
            var validator = new CreateTaxCommandValidator();
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
            if(response.Success)
            {
                newTax = await _taxRepository.AddAsync(newTax);
                response.TaxId = newTax.TaxId;
            }
            return response;
        }
    }
}
