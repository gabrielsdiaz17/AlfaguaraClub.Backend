using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CostcenterServices.CreateCostCenterCommands
{
    public class CreateCostcenterCommandHandler : IRequestHandler<CreateCostCenterCommand, long>
    {
        private readonly ICostCenterRepository _costCenterRepository;
        private readonly IMapper _mapper;
        public CreateCostcenterCommandHandler(ICostCenterRepository costCenterRepository, IMapper mapper)
        {
            _costCenterRepository = costCenterRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateCostCenterCommand request, CancellationToken cancellationToken)
        {
            var costCenter = _mapper.Map<CostCenter>(request);
            costCenter = await _costCenterRepository.AddAsync(costCenter);
            return costCenter.CostCenterId;
        }
    }
}
