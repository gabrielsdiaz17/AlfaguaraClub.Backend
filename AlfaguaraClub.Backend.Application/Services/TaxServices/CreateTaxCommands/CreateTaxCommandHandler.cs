using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TaxServices.CreateTaxCommands
{
    public class CreateTaxCommandHandler : IRequestHandler<CreateTaxCommand, int>
    {
        private readonly ITaxRepository _taxRepository;
        private readonly IMapper _mapper;
        public CreateTaxCommandHandler(ITaxRepository taxRepository, IMapper mapper)
        {
            _taxRepository = taxRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
        {
            var newTax = _mapper.Map<Tax>(request);
            newTax = await _taxRepository.AddAsync(newTax);
            return newTax.TaxId;
        }
    }
}
