using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CostcenterServices.QueryCostCenterCommands
{
    public class GetCostCenterQueryHandler : IRequestHandler<GetCostCenterQuery, CostCenterListVm>
    {
        private readonly ICostCenterRepository _costCenterRepository;
        private readonly IMapper _mapper;
        public GetCostCenterQueryHandler(ICostCenterRepository costCenterRepository, IMapper mapper)
        {
            _costCenterRepository = costCenterRepository;
            _mapper = mapper;
        }

        public async Task<CostCenterListVm> Handle(GetCostCenterQuery request, CancellationToken cancellationToken)
        {
            var costCenter = await _costCenterRepository.GetCostCenter(request.CostCenterId);
            return _mapper.Map<CostCenterListVm>(costCenter);
        }
    }
}
