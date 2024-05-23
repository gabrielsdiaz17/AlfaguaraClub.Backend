using AlfaguaraClub.Backend.Application.Contracts.Persistence;
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
            {
                
            }
            _mapper.Map(request, companyToUpdate, typeof(UpdateCompanyCommand),typeof(Company));
            await _companyRepository.UpdateAsync(companyToUpdate);
        }
    }
}
