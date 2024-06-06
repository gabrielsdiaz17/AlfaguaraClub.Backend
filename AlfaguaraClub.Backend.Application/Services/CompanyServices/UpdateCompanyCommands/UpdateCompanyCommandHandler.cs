using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Exceptions;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CompanyServices.UpdateCompanyCommands
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToUpdate = await _companyRepository.GetByIdAsync(request.CompanyId);
            if (companyToUpdate == null)            
                throw new NotFoundException(nameof(Company), request.CompanyId);
            var validator = new UpdateCommandValidator();
            var validationresult = await validator.ValidateAsync(request);
            if(validationresult.Errors.Count > 0)            
                throw new ValidationException(validationresult);
            
            _mapper.Map(request, companyToUpdate, typeof(UpdateCompanyCommand),typeof(Company));
            await _companyRepository.UpdateAsync(companyToUpdate);
        }
    }
}
