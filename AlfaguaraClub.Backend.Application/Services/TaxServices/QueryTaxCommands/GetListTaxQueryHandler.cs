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
    public class GetListTaxQueryHandler : IRequestHandler<GetListTaxQuery, List<TaxListVm>>
    {
        private readonly ITaxRepository _taxRepository;
        private readonly IMapper _mapper;
        public GetListTaxQueryHandler(ITaxRepository taxRepository, IMapper mapper)
        {
            _taxRepository = taxRepository;
            _mapper = mapper;
        }

        public async Task<List<TaxListVm>> Handle(GetListTaxQuery request, CancellationToken cancellationToken)
        {
            var listTaxes = await _taxRepository.GetTaxesActive();
            return _mapper.Map<List<TaxListVm>>(listTaxes);
        }
    }
}
