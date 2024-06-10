using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ProductServices.UpdateProductCommands
{
    public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.ProductCode)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder 20 carácteres.");
            RuleFor(x => x.ProductDescription)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder 20 carácteres.");
            RuleFor(x => x.UnitPrice)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .GreaterThan(0).WithMessage("{PropertyName} debe tener un valor mayor de Cero.");
        }
    }
}
