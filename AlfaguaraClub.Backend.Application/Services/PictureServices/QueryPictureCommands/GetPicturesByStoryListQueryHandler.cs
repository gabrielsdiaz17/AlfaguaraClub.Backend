using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.QueryPictureCommands
{
    public class GetPicturesByStoryListQueryHandler : IRequestHandler<GetPicturesByStoryListQuery, List<PictureListVm>>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IMapper _mapper;
        public GetPicturesByStoryListQueryHandler(IPictureRepository pictureRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }

        public async Task<List<PictureListVm>> Handle(GetPicturesByStoryListQuery request, CancellationToken cancellationToken)
        {
            var picturesByStory = await _pictureRepository.GetPicturesByStory(request.StoryId);
            return _mapper.Map<List<PictureListVm>>(picturesByStory);
        }
    }
}
