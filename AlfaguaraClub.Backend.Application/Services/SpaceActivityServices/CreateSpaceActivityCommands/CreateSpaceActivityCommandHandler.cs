using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.CreateSpaceActivityCommands
{
    public class CreateSpaceActivityCommandHandler : IRequestHandler<CreateSpaceActivityCommand, CreateSpaceActivityCommandResponse>
    {
        private readonly ISpaceActivityRepository _spaceActivityRepository;
        private readonly IMapper _mapper;
        public CreateSpaceActivityCommandHandler(ISpaceActivityRepository spaceActivityRepository, IMapper mapper)
        {
            _spaceActivityRepository = spaceActivityRepository;
            _mapper = mapper;
        }
        public async Task<CreateSpaceActivityCommandResponse> Handle(CreateSpaceActivityCommand request, CancellationToken cancellationToken)
        {
            var createSpaceActivityResponse = new CreateSpaceActivityCommandResponse();
            var spaceActivity = _mapper.Map<SpaceActivity>(request);
            var validator = new CreateSpaceActivityCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count >0)
            {
                createSpaceActivityResponse.Success = false;
                createSpaceActivityResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createSpaceActivityResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createSpaceActivityResponse.Success)
            {
                spaceActivity = await _spaceActivityRepository.AddAsync(spaceActivity);
                createSpaceActivityResponse.SpaceActivityId = spaceActivity.SpaceActivityId;
            }            
            return createSpaceActivityResponse;
        }
    }
}
