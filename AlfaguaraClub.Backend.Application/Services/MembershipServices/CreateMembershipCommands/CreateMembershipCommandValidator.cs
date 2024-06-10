using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.MembershipServices.CreateMembershipCommands
{
    public class CreateMembershipCommandValidator:AbstractValidator<CreateMembershipCommand>
    {
        public CreateMembershipCommandValidator()
        {
            RuleFor(x => x.UniqueIdentifier)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe ser mayor de 50  caracteres")
                .NotNull();
        }
    }
}
