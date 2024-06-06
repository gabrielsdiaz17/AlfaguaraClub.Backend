using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.CreateSpaceCommands
{
    public class CreateSpaceCommandHandler : IRequestHandler<CreateSpaceCommand, CreateSpaceCommandResponse>
    {
        private readonly ISpaceRepository _spaceRepository;
        private readonly IMapper _mapper;
        public CreateSpaceCommandHandler(ISpaceRepository spaceRepository, IMapper mapper)
        {
            _spaceRepository = spaceRepository;
            _mapper = mapper;
        }
        public async Task<CreateSpaceCommandResponse> Handle(CreateSpaceCommand request, CancellationToken cancellationToken)
        {
            var createSpaceCommandResponse = new CreateSpaceCommandResponse();
            var space = _mapper.Map<Space>(request);
            var validator = new CreateSpaceCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Count > 0) 
            {
                createSpaceCommandResponse.Success = false;
                createSpaceCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createSpaceCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createSpaceCommandResponse.Success)
            {
                space = await _spaceRepository.AddAsync(space);
                createSpaceCommandResponse.SpaceId = space.SpaceId;
            }            
            return createSpaceCommandResponse;
        }
    }
}
