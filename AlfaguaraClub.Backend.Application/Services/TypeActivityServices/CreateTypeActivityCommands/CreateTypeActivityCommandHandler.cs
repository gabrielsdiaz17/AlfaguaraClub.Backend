using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TypeActivityServices.CreateTypeActivityCommands
{
    public class CreateTypeActivityCommandHandler : IRequestHandler<CreateTypeActivityCommand, int>
    {
        private readonly ITypeActivityRepository _typeActivityRepository;
        private readonly IMapper _mapper;
        public CreateTypeActivityCommandHandler(ITypeActivityRepository typeActivityRepository, IMapper mapper)
        {
            _typeActivityRepository = typeActivityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTypeActivityCommand request, CancellationToken cancellationToken)
        {
            var typeActivity = _mapper.Map<TypeActivity>(request);
            typeActivity = await _typeActivityRepository.AddAsync(typeActivity);
            return typeActivity.TypeActivityId;
        }
    }
}
