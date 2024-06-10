using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TypeActivityServices.CreateTypeActivityCommands
{
    public class CreateTypeActivityCommandHandler : IRequestHandler<CreateTypeActivityCommand, CreateTypeActivityCommandResponse>
    {
        private readonly ITypeActivityRepository _typeActivityRepository;
        private readonly IMapper _mapper;
        public CreateTypeActivityCommandHandler(ITypeActivityRepository typeActivityRepository, IMapper mapper)
        {
            _typeActivityRepository = typeActivityRepository;
            _mapper = mapper;
        }

        public async Task<CreateTypeActivityCommandResponse> Handle(CreateTypeActivityCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateTypeActivityCommandResponse();
            var typeActivity = _mapper.Map<TypeActivity>(request);
            var validator = new CreateTypeActivityCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
            }
            if(response.Success)
            {
                typeActivity = await _typeActivityRepository.AddAsync(typeActivity);
                response.TypeActivityId = typeActivity.TypeActivityId;
            }
            return response;
        }
    }
}
