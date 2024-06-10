using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.PaymentMethodServices.UpdatePaymentMethodCommands
{
    public class UpdatePaymentMethodCommandValidator: AbstractValidator<UpdatePaymentMethodCommand>
    {
        public UpdatePaymentMethodCommandValidator()
        {
            RuleFor(x => x.PaymentMethodCode)
               .NotEmpty().WithMessage("{PropertyName} es requerido.")
               .MaximumLength(50).WithMessage("{PropertyName} no debe exceder 50 carácteres.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder 200 carácteres.");
        }
    }
}
