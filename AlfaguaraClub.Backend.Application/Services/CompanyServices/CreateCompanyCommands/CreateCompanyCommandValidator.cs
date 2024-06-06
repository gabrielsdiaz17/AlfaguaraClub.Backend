using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands
{
    public class CreateCompanyCommandValidator:AbstractValidator<CreateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCommandValidator(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder 100 carácteres.");

            RuleFor(x => x.CompanyIdentifier)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder 20 carácteres.");

            RuleFor(x => x.IdentificationTypeId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().GreaterThan(0);
            RuleFor(x => x)
                .MustAsync(CompanyNameAndIdentifierUnique)
                .WithMessage("Una compañia con el mismo Nombre e Identificación ya existe");
        }
        private async Task<bool> CompanyNameAndIdentifierUnique(CreateCompanyCommand command,CancellationToken token)
        {
            return !await _companyRepository.IsCompanyNameAndIdentifierUnique(command.CompanyName, command.CompanyIdentifier);
        }
    }
}
