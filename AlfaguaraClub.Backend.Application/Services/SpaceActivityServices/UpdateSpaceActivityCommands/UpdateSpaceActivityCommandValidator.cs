﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.UpdateSpaceActivityCommands
{
    public class UpdateSpaceActivityCommandValidator:AbstractValidator<UpdateSpaceActivityCommand>
    {
        public UpdateSpaceActivityCommandValidator()
        {
            RuleFor(x => x.ActivityName)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder 200 carácteres.");

            RuleFor(x => x.ActivityDescription)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull();
            RuleFor(x => x.ActivityDate)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull();

            RuleFor(x => x.AvailableQuorum)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0).WithMessage("{PropertyName} debe ser mayor que Cero (0)");
        }
    }
}
