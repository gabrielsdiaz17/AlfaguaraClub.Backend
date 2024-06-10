using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ParameterServices.CreateParameterCommands
{
    public class CreateParameterCommandValidator:AbstractValidator<CreateParameterCommand>
    {
        public CreateParameterCommandValidator()
        {
            
            RuleFor(x => x.ParameterName)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 carácteres.");
            RuleFor(x => x.ParameterValue)
                .NotEmpty().WithMessage("{PropertyName} es requerido.");
        }
    }
}
