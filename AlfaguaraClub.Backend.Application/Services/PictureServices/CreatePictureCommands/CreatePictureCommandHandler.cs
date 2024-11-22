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
    public class CreatePictureCommandHandler : IRequestHandler<CreatePictureCommand, CreatePictureCommandResponse>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IMapper _mapper;
        public CreatePictureCommandHandler(IPictureRepository pictureRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }

        public async Task<CreatePictureCommandResponse> Handle(CreatePictureCommand request, CancellationToken cancellationToken)
        {
            var response = new CreatePictureCommandResponse();
            var newPicture = _mapper.Map<Picture>(request);
            var validator = new CreatePictureCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            
            if (response.Success)
            {
                string filePath = string.Empty;
                if (request.PictureFile != null && request.PictureFile.Length > 0)
                {
                    string uploadDir = Path.Combine("wwwroot", "uploads", "images");
                    if (!Directory.Exists(uploadDir))
                        Directory.CreateDirectory(uploadDir);

                    string fileName = $"{Guid.NewGuid()}_{request.PictureFile.FileName}";
                    filePath = Path.Combine(uploadDir, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.PictureFile.CopyToAsync(fileStream);
                    }

                    filePath = $"/uploads/images/{fileName}"; // Relative path for serving through the API
                }
                newPicture.PictureData = filePath; // Save the relative path

                newPicture = await _pictureRepository.AddAsync(newPicture);
                response.PictureId = newPicture.PictureId;
            }
            return response;
        }
    }
}
