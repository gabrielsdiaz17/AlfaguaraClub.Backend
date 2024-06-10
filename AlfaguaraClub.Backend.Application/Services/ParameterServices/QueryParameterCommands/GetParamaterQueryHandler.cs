using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ParameterServices.QueryParameterCommands
{
    public class GetParamaterQueryHandler : IRequestHandler<GetParameterQuery, ParameterListVm>
    {
        private readonly IParameterRepository _parameterRepository;
        private readonly IMapper _mapper;
        public GetParamaterQueryHandler(IMapper mapper, IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
            _mapper = mapper;
        }
        public async Task<ParameterListVm> Handle(GetParameterQuery request, CancellationToken cancellationToken)
        {
            var parameter = await _parameterRepository.GetParameterByName(request.ParameterName);
            return _mapper.Map<ParameterListVm>(parameter);
        }
    }

}
