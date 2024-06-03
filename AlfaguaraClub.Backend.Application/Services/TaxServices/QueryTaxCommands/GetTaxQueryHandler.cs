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
    public class GetTaxQueryHandler : IRequestHandler<GetTaxQuery, TaxListVm>
    {
        private readonly ITaxRepository _taxRepository;
        private readonly IMapper _mapper;
        public GetTaxQueryHandler(ITaxRepository taxRepository, IMapper mapper)
        {
            _taxRepository = taxRepository;
            _mapper = mapper;
        }

        public async Task<TaxListVm> Handle(GetTaxQuery request, CancellationToken cancellationToken)
        {
            var taxById = await _taxRepository.GetTaxById(request.TaxId);
            return _mapper.Map<TaxListVm>(taxById);
        }
    }
}
