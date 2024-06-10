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
    public class CreateCostcenterCommandHandler : IRequestHandler<CreateCostCenterCommand, CreateCostCenterCommandResponse>
    {
        private readonly ICostCenterRepository _costCenterRepository;
        private readonly IMapper _mapper;
        public CreateCostcenterCommandHandler(ICostCenterRepository costCenterRepository, IMapper mapper)
        {
            _costCenterRepository = costCenterRepository;
            _mapper = mapper;
        }

        public async Task<CreateCostCenterCommandResponse> Handle(CreateCostCenterCommand request, CancellationToken cancellationToken)
        {
            var createCostCenterResponse = new CreateCostCenterCommandResponse();
            var costCenter = _mapper.Map<CostCenter>(request);
            var validator = new CreateCostCenterCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count >0 ) 
            {
                createCostCenterResponse.Success = false;
                createCostCenterResponse.ValidationErrors = new List<string>();
                foreach ( var error in validationResult.Errors )
                {
                    createCostCenterResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCostCenterResponse.Success)
            {
                costCenter = await _costCenterRepository.AddAsync(costCenter);
                createCostCenterResponse.CostCenterId = costCenter.CostCenterId;
            }
            return createCostCenterResponse;
        }
    }
}
