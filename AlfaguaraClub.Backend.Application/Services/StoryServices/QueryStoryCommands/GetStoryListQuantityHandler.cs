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
    public class GetStoryListQuantityHandler : IRequestHandler<GetStoryListQuantity, List<StoryListVm>>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;
        public GetStoryListQuantityHandler(IStoryRepository storyRepository, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
        }

        public async Task<List<StoryListVm>> Handle(GetStoryListQuantity request, CancellationToken cancellationToken)
        {
            var storyQuantities = await _storyRepository.GetQuantityStories(request.QuantityStories);
            return _mapper.Map<List<StoryListVm>>(storyQuantities);
        }
    }
}
