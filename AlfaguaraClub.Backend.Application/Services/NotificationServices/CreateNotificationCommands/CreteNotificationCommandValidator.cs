using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationServices.CreateNotificationCommands
{
    public class CreteNotificationCommandValidator:AbstractValidator<CreateNotificationCommand>
    {
        public CreteNotificationCommandValidator()
        {
            RuleFor(x => x.NotificationTypeId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull();

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                ;
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 carácteres.");
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("{PropertyName} es requerido.");
        }
    }
}
