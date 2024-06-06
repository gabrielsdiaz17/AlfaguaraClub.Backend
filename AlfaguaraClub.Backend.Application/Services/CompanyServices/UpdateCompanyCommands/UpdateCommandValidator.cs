using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CompanyServices.UpdateCompanyCommands
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder 100 carácteres.");

            RuleFor(x => x.CompanyIdentifier)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder 20 carácteres.");

            RuleFor(x => x.IdentificationTypeId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0);
        }

    }
}
