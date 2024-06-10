using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.UpdateNotificationTypeCommands
{
    public class UpdateNotificationTypeCommandValidator: AbstractValidator<UpdateNotificationTypeCommand>
    {
        public UpdateNotificationTypeCommandValidator()
        {
            RuleFor(x => x.NotificationTypeDescription)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(500).WithMessage("{PropertyName} no debe ser mayor de 500  caracteres")
                .NotNull();
        }
    }
}
