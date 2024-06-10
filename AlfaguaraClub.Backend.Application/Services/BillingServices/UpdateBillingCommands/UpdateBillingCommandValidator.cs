using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.UpdateBillingCommands
{
    public class UpdateBillingCommandValidator:AbstractValidator<UpdateBillingCommand>
    {
        public UpdateBillingCommandValidator()
        {
            RuleFor(x => x.BillingDate)
               .NotEmpty().WithMessage("{PropertyName} es requerido.")
               .NotNull();

            RuleFor(x => x.BillingConsecutive)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder 50 carácteres.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0);

            RuleFor(x => x.BillingStatusId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0);

            RuleFor(x => x.PaymentMethodId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0);
        }
    }
}
