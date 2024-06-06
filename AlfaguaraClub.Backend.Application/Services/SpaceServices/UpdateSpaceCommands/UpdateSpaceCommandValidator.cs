using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceServices.UpdateSpaceCommands
{
    public class UpdateSpaceCommandValidator:AbstractValidator<UpdateSpaceCommand>
    {
        public UpdateSpaceCommandValidator()
        {
            RuleFor(x => x.SpaceName)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder 200 carácteres.");

            RuleFor(x => x.SpaceDescription)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull();

            RuleFor(x => x.CostCenterId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0);
        }
    }
}
