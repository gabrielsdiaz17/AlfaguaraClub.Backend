using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.RoleServices.CreateRoleCommands
{
    public class CreateRoleCommandValidator: AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder 200 carácteres.");
        }
    }
}
