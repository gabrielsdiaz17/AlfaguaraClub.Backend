using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TypeActivityServices.QueryTypeActivityCommands
{
    public class GetTypeActivityListQueryHandler : IRequestHandler<GetTypeActivityListQuery, List<TypeActivityListVm>>
    {
        private readonly ITypeActivityRepository _typeActivityRepository;
        private readonly IMapper _mapper;

        public GetTypeActivityListQueryHandler(ITypeActivityRepository typeActivityRepository, IMapper mapper)
        {
            _typeActivityRepository = typeActivityRepository;
            _mapper = mapper;
        }

        public async Task<List<TypeActivityListVm>> Handle(GetTypeActivityListQuery request, CancellationToken cancellationToken)
        {
            var typeActivity = await _typeActivityRepository.GetAllAsync();
            return _mapper.Map<List<TypeActivityListVm>>(typeActivity);
        }
    }
}
