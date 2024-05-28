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
    public class GetStoryListByCategoryHandler : IRequestHandler<GetStoryListByCategory, List<StoryListVm>>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;
        public GetStoryListByCategoryHandler(IStoryRepository storyRepository, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
        }
        public async Task<List<StoryListVm>> Handle(GetStoryListByCategory request, CancellationToken cancellationToken)
        {
            var storiesByCategory = await _storyRepository.GetStoriesByCategory(request.CategoryId);
            return _mapper.Map<List<StoryListVm>>(storiesByCategory);
        }
    }
}
