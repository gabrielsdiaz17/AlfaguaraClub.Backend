using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Exceptions;
using AlfaguaraClub.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.DeletePictureCommands
{
    public class DeletePictureCommandHandler : IRequestHandler<DeletePictureCommand>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly string _basePath = Path.Combine("wwwroot", "uploads", "images");
        public DeletePictureCommandHandler(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        public async Task Handle(DeletePictureCommand request, CancellationToken cancellationToken)
        {
            var picture = await _pictureRepository.GetByIdAsync(request.PictureId);
            if (picture == null)
                throw new NotFoundException(nameof(Picture), request.PictureId);

            // Soft delete (mark inactive)
            picture.IsActive = false;
            await _pictureRepository.UpdateAsync(picture);

            // Delete the image file from disk
            if (!string.IsNullOrEmpty(picture.PictureData))
            {
                var filePath = Path.Combine(_basePath, Path.GetFileName(picture.PictureData));
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }
    }
}
