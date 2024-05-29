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
    public class CreateParameterCommandHandler : IRequestHandler<CreateParameterCommand, long>
    {
        private readonly IParameterRepository _parameterRepository;
        private readonly IMapper _mapper;
        public CreateParameterCommandHandler(IParameterRepository parameterRepository, IMapper mapper)
        {
            _parameterRepository = parameterRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateParameterCommand request, CancellationToken cancellationToken)
        {
            var newParameter = _mapper.Map<Parameter>(request);
            newParameter = await _parameterRepository.AddAsync(newParameter);
            return newParameter.ParameterId;
        }
    }
}
