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

namespace AlfaguaraClub.Backend.Application.Services.StoryServices.UpdateStoryCommands
{
    public class UpdateStoryCommandHandler : IRequestHandler<UpdateStoryCommand>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;
        public UpdateStoryCommandHandler(IStoryRepository storyRepository, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateStoryCommand request, CancellationToken cancellationToken)
        {
            var storyToUpdate = await _storyRepository.GetByIdAsync(request.StoryId);
            if(storyToUpdate == null)
                throw new NotFoundException(nameof(Story), request.StoryId);
            var validator = new UpdateStoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count() > 0)
                throw new ValidationException(validationResult);
            _mapper.Map(request, storyToUpdate, typeof(UpdateStoryCommand), typeof(Story));
            await _storyRepository.UpdateAsync(storyToUpdate);
        }
    }
}
