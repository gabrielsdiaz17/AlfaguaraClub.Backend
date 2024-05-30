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
    public class GetPictureQueryHandler : IRequestHandler<GetPictureQuery, PictureListVm>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IMapper _mapper;
        public GetPictureQueryHandler(IPictureRepository pictureRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }

        public async Task<PictureListVm> Handle(GetPictureQuery request, CancellationToken cancellationToken)
        {
            var picture = await _pictureRepository.GetPictureById(request.PictureId);
            return _mapper.Map<PictureListVm>(picture);
        }
    }
}
