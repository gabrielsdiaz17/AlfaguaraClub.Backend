using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ParameterServices.CreateParameterCommands
{
    public class CreateParameterCommandHandler : IRequestHandler<CreateParameterCommand, CreateParameterCommandResponse>
    {
        private readonly IParameterRepository _parameterRepository;
        private readonly IMapper _mapper;
        public CreateParameterCommandHandler(IParameterRepository parameterRepository, IMapper mapper)
        {
            _parameterRepository = parameterRepository;
            _mapper = mapper;
        }

        public async Task<CreateParameterCommandResponse> Handle(CreateParameterCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateParameterCommandResponse();
            var newParameter = _mapper.Map<Parameter>(request);
            var validator = new CreateParameterCommandValidator();
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
                newParameter = await _parameterRepository.AddAsync(newParameter);
                response.ParameterId = newParameter.ParameterId;
            }
            return response;
        }
    }
}
