using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StoryServices.QueryStoryCommands
{
    public class GetStoryQueryHandler : IRequestHandler<GetStoryQuery, StoryListVm>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;
        public GetStoryQueryHandler(IStoryRepository storyRepository, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
        }

        public async Task<StoryListVm> Handle(GetStoryQuery request, CancellationToken cancellationToken)
        {
            var storyById = await _storyRepository.GetStoryByStoryId(request.StoryId);
            if (storyById == null) { }
            return _mapper.Map<StoryListVm>(storyById);
        }
    }
}
