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
    public class GetPicturesBySpaceListQueryHandler : IRequestHandler<GetPicturesBySpaceListQuery, List<PictureListVm>>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IMapper _mapper;
        public GetPicturesBySpaceListQueryHandler(IPictureRepository pictureRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }

        public async Task<List<PictureListVm>> Handle(GetPicturesBySpaceListQuery request, CancellationToken cancellationToken)
        {
            var picturesSpace = await _pictureRepository.GetPicturesBySpace(request.SpaceId);
            return _mapper.Map<List<PictureListVm>>(picturesSpace);
        }
    }
}
