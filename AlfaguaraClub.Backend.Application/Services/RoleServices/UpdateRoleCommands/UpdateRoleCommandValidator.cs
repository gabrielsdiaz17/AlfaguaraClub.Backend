using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.RoleServices.UpdateRoleCommands
{
    public class UpdateRoleCommandValidator:AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder 200 carácteres.");
        }
    }
}
