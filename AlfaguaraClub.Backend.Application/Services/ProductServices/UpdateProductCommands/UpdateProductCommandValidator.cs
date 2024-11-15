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
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder 200 carácteres.");
            RuleFor(x => x.ProductDescription)
               .NotEmpty().WithMessage("{PropertyName} es requerido.")
               .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 carácteres.");
        }
    }
}
