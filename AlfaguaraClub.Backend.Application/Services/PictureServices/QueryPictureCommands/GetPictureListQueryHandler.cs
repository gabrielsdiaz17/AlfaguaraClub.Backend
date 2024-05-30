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
    public class GetPictureListQueryHandler : IRequestHandler<GetPictureListQuery, List<PictureListVm>>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IMapper _mapper;
        public GetPictureListQueryHandler(IPictureRepository pictureRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }

        public async Task<List<PictureListVm>> Handle(GetPictureListQuery request, CancellationToken cancellationToken)
        {
            var pictureList = await _pictureRepository.GetActivePictures();
            return _mapper.Map<List<PictureListVm>>(pictureList);
        }
    }
}
