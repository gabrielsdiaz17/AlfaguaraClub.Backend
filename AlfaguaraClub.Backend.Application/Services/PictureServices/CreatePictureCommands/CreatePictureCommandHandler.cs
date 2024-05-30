using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.CreatePictureCommands
{
    public class CreatePictureCommandHandler : IRequestHandler<CreatePictureCommand, long>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IMapper _mapper;
        public CreatePictureCommandHandler(IPictureRepository pictureRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreatePictureCommand request, CancellationToken cancellationToken)
        {
            var newPicture = _mapper.Map<Picture>(request);
            newPicture = await _pictureRepository.AddAsync(newPicture);
            return newPicture.PictureId;
        }
    }
}
