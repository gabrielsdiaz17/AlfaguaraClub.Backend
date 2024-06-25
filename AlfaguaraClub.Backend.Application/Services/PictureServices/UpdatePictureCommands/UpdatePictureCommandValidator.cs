using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.UpdatePictureCommands
{
    public class UpdatePictureCommandValidator:AbstractValidator<UpdatePictureCommand>
    {
        public UpdatePictureCommandValidator()
        {
            RuleFor(x => x.PictureName)
               .NotEmpty().WithMessage("{PropertyName} es requerido.");
            RuleFor(x => x.PictureData)
               .NotEmpty().WithMessage("{PropertyName} es requerido.");
            RuleFor(x => x.PictureType)
                .NotEmpty().WithMessage("{PropertyName} es requerido.");
        }
    }
}
