using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.CreateIdentificationTypeCommands
{
    public class CreateIdentificationTypeCommandHandler : IRequestHandler<CreateIdentificationTypeCommand, int>
    {
        private readonly IIdentificationTypeRepository _identifierTypeRepository;
        private readonly IMapper _mapper;
        public CreateIdentificationTypeCommandHandler(IIdentificationTypeRepository identifierTypeRepository, IMapper mapper)
        {
            _identifierTypeRepository = identifierTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateIdentificationTypeCommand request, CancellationToken cancellationToken)
        {
            var newIdentificationType = _mapper.Map<IdentificationType>(request);
            newIdentificationType = await _identifierTypeRepository.AddAsync(newIdentificationType);
            return newIdentificationType.IdendificationTypeId;
        }
    }
}
