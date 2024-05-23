using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CostcenterServices.UpdateCostCenterCommands
{
    public class UpdateCostCenterCommandHandler : IRequestHandler<UpdateCostCenterCommand>
    {
        private readonly ICostCenterRepository _costCenterRepository;
        private readonly IMapper _mapper;
        public UpdateCostCenterCommandHandler(ICostCenterRepository costCenterRepository, IMapper mapper)
        {
            _costCenterRepository = costCenterRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCostCenterCommand request, CancellationToken cancellationToken)
        {
            var costCenterToUpdate = await _costCenterRepository.GetByIdAsync(request.CostCenterId);
            if(costCenterToUpdate == null) { }
            _mapper.Map(request, costCenterToUpdate, typeof(UpdateCostCenterCommand),typeof(CostCenter));
            await _costCenterRepository.UpdateAsync(costCenterToUpdate);
        }
    }
}
