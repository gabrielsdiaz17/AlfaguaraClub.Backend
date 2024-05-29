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
    public class GetParameterListQueryHandler : IRequestHandler<GetParameterListQuery, List<ParameterListVm>>
    {
        private readonly IParameterRepository _parameterRepository;
        private readonly IMapper _mapper;
        public GetParameterListQueryHandler(IParameterRepository parameterRepository, IMapper mapper)
        {
            _parameterRepository = parameterRepository;
            _mapper = mapper;
        }

        public async Task<List<ParameterListVm>> Handle(GetParameterListQuery request, CancellationToken cancellationToken)
        {
            var parameters = await _parameterRepository.GetParameters();
            return _mapper.Map<List<ParameterListVm>>(parameters);
        }
    }
}
