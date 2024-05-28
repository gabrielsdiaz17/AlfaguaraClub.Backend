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
    public class GetStoryListQueryHandler : IRequestHandler<GetStoryListQuery, List<StoryListVm>>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;
        public GetStoryListQueryHandler(IStoryRepository storyRepository, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
        }

        public async Task<List<StoryListVm>> Handle(GetStoryListQuery request, CancellationToken cancellationToken)
        {
            var stories = await _storyRepository.GetStories();
            return _mapper.Map<List<StoryListVm>>(stories);
        }
    }
}
