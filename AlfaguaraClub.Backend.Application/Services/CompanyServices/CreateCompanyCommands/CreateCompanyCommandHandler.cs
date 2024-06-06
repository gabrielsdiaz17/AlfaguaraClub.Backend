using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands
{
    public class CreateCompanyCommandHandler: IRequestHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var createCompanyCommandResponse = new CreateCompanyCommandResponse();
            var company = _mapper.Map<Company>(request);
            var validator = new CreateCompanyCommandValidator(_companyRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                createCompanyCommandResponse.Success = false;
                createCompanyCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCompanyCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCompanyCommandResponse.Success)
            {
                company = await _companyRepository.AddAsync(company);
                createCompanyCommandResponse.CompanyId = company.CompanyId;
            }
            return createCompanyCommandResponse;
        }
    }
}
