using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingDetailServices.UpdateBillingDetailCommands
{
    public class UpdateBillingDetailCommandValidator:AbstractValidator<UpdateBillingDetailCommand>
    {
        public UpdateBillingDetailCommandValidator()
        {
            RuleFor(x => x.BillingId)
               .NotEmpty().WithMessage("{PropertyName} es requerido. El item debe estar asociado a una factura")
               .NotNull().GreaterThan(0);

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0);

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0);

            RuleFor(x => x.TotalPrice)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0);
        }
    }
}
