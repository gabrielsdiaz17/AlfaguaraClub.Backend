using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.CreateIdentificationTypeCommands
{
    public class CreateIdentificationTypeCommandHandler : IRequestHandler<CreateIdentificationTypeCommand, CreateIdentificationTypeCommandResponse>
    {
        private readonly IIdentificationTypeRepository _identifierTypeRepository;
        private readonly IMapper _mapper;
        public CreateIdentificationTypeCommandHandler(IIdentificationTypeRepository identifierTypeRepository, IMapper mapper)
        {
            _identifierTypeRepository = identifierTypeRepository;
            _mapper = mapper;
        }

        public async Task<CreateIdentificationTypeCommandResponse> Handle(CreateIdentificationTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateIdentificationTypeCommandResponse();
            var newIdentificationType = _mapper.Map<IdentificationType>(request);
            var validator = new CreateIdentificationTyperCommandValidator();
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
                newIdentificationType = await _identifierTypeRepository.AddAsync(newIdentificationType);
                response.IdendificationTypeId = newIdentificationType.IdendificationTypeId;
            }
            return response;
        }
    }
}
