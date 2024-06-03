using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TaxServices.QueryTaxCommands
{
    public class GetTaxByNameQueryHandler : IRequestHandler<GetTaxByNameQuery, TaxListVm>
    {
        private readonly ITaxRepository _taxRepository;
        private readonly IMapper _mapper;
        public GetTaxByNameQueryHandler(ITaxRepository taxRepository, IMapper mapper)
        {
            _taxRepository = taxRepository;
            _mapper = mapper;
        }

        public async Task<TaxListVm> Handle(GetTaxByNameQuery request, CancellationToken cancellationToken)
        {
            var taxByName = await _taxRepository.GetTaxByName(request.TaxName);
            return _mapper.Map<TaxListVm>(taxByName);
        }
    }
}
