using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TypeActivityServices.UpdateTypeActivityCommands
{
    public class UpdateTypeActivityCommandValidator: AbstractValidator<UpdateTypeActivityCommand>
    {
        public UpdateTypeActivityCommandValidator()
        {
            RuleFor(x => x.TypeActivityName)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder 100 carácteres.");
        }
    }
}
