using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Exceptions;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ParameterServices.UpdateParameterCommands
{
    public class UpdateParameterCommandHandler : IRequestHandler<UpdateParameterCommand>
    {
        private readonly IParameterRepository _parameterRepository;
        private readonly IMapper _mapper;
        public UpdateParameterCommandHandler(IParameterRepository parameterRepository, IMapper mapper)
        {
            _parameterRepository = parameterRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateParameterCommand request, CancellationToken cancellationToken)
        {
            var parameterToUpdate = await _parameterRepository.GetByIdAsync(request.ParameterId);
            if (parameterToUpdate == null)
                throw new NotFoundException(nameof(Parameter), request.ParameterId);
            var validator = new UpdateParameterCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            _mapper.Map(request, parameterToUpdate, typeof(UpdateParameterCommand), typeof(Parameter));
            await _parameterRepository.UpdateAsync(parameterToUpdate);
        }
    }
}
