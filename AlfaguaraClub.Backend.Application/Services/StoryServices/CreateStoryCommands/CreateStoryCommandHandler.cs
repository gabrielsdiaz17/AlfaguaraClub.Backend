using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StoryServices.CreateStoryCommands
{
    public class CreateStoryCommandHandler : IRequestHandler<CreateStoryCommand, CreateStoryCommandResponse>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;
        public CreateStoryCommandHandler(IStoryRepository storyRepository, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
        }

        public async Task<CreateStoryCommandResponse> Handle(CreateStoryCommand request, CancellationToken cancellationToken)
        {
            var createStoryCommandResponse = new CreateStoryCommandResponse();
            var newStory = _mapper.Map<Story>(request);
            var validator = new CreateStoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count() >0)
            {
                createStoryCommandResponse.Success = false;
                createStoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createStoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createStoryCommandResponse.Success)
            {
                newStory = await _storyRepository.AddAsync(newStory);
                createStoryCommandResponse.StoryId = newStory.StoryId;
            }
            
            return createStoryCommandResponse;
        }
    }
}
