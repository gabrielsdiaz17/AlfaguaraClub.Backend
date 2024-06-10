using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CostcenterServices.CreateCostCenterCommands
{
    public class CreateCostCenterCommandValidator:AbstractValidator<CreateCostCenterCommand>
    {
        public CreateCostCenterCommandValidator()
        {
            

            RuleFor(x => x.CostCenterCode)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder 20 carácteres.");

            RuleFor(x => x.CostCenterName)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder 200 carácteres.");


            RuleFor(x => x.SiteId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0);

        }
    }
}
