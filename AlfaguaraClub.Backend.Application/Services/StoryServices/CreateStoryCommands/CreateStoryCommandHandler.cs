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
    public class CreateStoryCommandHandler : IRequestHandler<CreateStoryCommand, long>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;
        public CreateStoryCommandHandler(IStoryRepository storyRepository, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateStoryCommand request, CancellationToken cancellationToken)
        {
            var newStory = _mapper.Map<Story>(request);
            newStory = await _storyRepository.AddAsync(newStory);
            return newStory.StoryId;
        }
    }
}
