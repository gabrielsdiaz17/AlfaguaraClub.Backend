using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ContactRequestServices.CreateContactRequestCommands
{
    public class CreateContactRequestCommandValidator: AbstractValidator<CreateContactRequestCommand>
    {
        public CreateContactRequestCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder 100 carácteres.");
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull();
                
        }
    }
}
