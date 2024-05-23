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
    public class GetCostCenterListQueryHandler : IRequestHandler<GetCostCenterListQuery, List<CostCenterListVm>>
    {
        private readonly ICostCenterRepository _costCenterRepository;
        private readonly IMapper _mapper;
        public GetCostCenterListQueryHandler(ICostCenterRepository costCenterRepository, IMapper mapper)
        {
            _costCenterRepository = costCenterRepository;
            _mapper = mapper;
        }

        public async Task<List<CostCenterListVm>> Handle(GetCostCenterListQuery request, CancellationToken cancellationToken)
        {
            var costCenterWithSpaces = await _costCenterRepository.GetCostCenterWithSpaces();
            return _mapper.Map<List<CostCenterListVm>>(costCenterWithSpaces);
        }
    }
}
