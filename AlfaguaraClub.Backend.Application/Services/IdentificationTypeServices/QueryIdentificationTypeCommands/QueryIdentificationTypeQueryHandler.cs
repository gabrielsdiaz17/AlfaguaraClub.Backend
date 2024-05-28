using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.QueryIdentificationTypeCommands
{
    public class QueryIdentificationTypeQueryHandler : IRequestHandler<QueryIdentificationTypeQuery, List<IdentificationTypeListVm>>
    {
        private readonly IIdentificationTypeRepository _identifierTypeRepository;
        private readonly IMapper _mapper;
        public QueryIdentificationTypeQueryHandler(IIdentificationTypeRepository identifierTypeRepository, IMapper mapper)
        {
            _identifierTypeRepository = identifierTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<IdentificationTypeListVm>> Handle(QueryIdentificationTypeQuery request, CancellationToken cancellationToken)
        {
            var identificationTypes = await _identifierTypeRepository.GetAllAsync();
            return _mapper.Map<List<IdentificationTypeListVm>>(identificationTypes);
        }
    }
}
