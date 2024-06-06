using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SiteServices.CreateSiteCommands
{
    public class CreateSiteCommandValidator:AbstractValidator<CreateSiteCommand>
    {
        public CreateSiteCommandValidator()
        {
            RuleFor(x => x.SiteName)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder 200 carácteres.");

            RuleFor(x => x.SiteAddress)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 carácteres.");

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0);
        }
    }
}
