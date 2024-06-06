using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.StoryServices.UpdateStoryCommands
{
    public class UpdateStoryCommandValidator:AbstractValidator<UpdateStoryCommand>
    {
        public UpdateStoryCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 carácteres.");

            RuleFor(x => x.Summary)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 carácteres.");

            RuleFor(x => x.StoryPublishDate)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull();
        }
    }
}
