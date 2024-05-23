using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CompanyServices
{
    public class GetCompanyListQueryHandler : IRequestHandler<GetCompanyListQuery, List<CompanyListVm>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public GetCompanyListQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyListVm>> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
        {
            var companies = (await _companyRepository.GetAllAsync()).OrderByDescending(x => x.CompanyId);
            return _mapper.Map<List<CompanyListVm>>(companies);
        }
    }
}
