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

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.UpdatePictureCommands
{
    public class UpdatePictureCommandHandler : IRequestHandler<UpdatePictureCommand>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IMapper _mapper;
        public UpdatePictureCommandHandler(IPictureRepository pictureRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePictureCommand request, CancellationToken cancellationToken)
        {
            var pictureToUpdate = await _pictureRepository.GetByIdAsync(request.PictureId);
            if (pictureToUpdate == null)
                throw new NotFoundException(nameof(Picture), request.PictureId);
            _mapper.Map(request, pictureToUpdate, typeof(UpdatePictureCommand), typeof(Picture));
            var validator = new UpdatePictureCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            await _pictureRepository.UpdateAsync(pictureToUpdate);
        }
    }
}
