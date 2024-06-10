using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PictureServices.CreatePictureCommands
{
    public class CreatePictureCommandValidator:AbstractValidator<CreatePictureCommand>
    {
        public CreatePictureCommandValidator()
        {
            RuleFor(x => x.PictureData)
               .NotEmpty().WithMessage("{PropertyName} es requerido.");
            RuleFor(x => x.PictureType)
                .NotEmpty().WithMessage("{PropertyName} es requerido.");
                
        }
    }
}
