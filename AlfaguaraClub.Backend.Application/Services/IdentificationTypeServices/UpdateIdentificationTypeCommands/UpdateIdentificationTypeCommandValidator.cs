using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.UpdateIdentificationTypeCommands
{
    public class UpdateIdentificationTypeCommandValidator:AbstractValidator<UpdateIdentificationTypeCommand>
    {
        public UpdateIdentificationTypeCommandValidator()
        {
            RuleFor(x => x.IdentificationTypeCode)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0);
            RuleFor(x => x.Nomenclature)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull();
        }
    }
}
