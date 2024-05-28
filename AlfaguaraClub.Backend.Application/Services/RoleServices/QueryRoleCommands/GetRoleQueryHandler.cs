using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.RoleServices.QueryRoleCommands
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, RoleListVm>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public GetRoleQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleListVm> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var roleByIdWithUser = await _roleRepository.GetUsersByRoleId(request.RoleId);
            return _mapper.Map<RoleListVm>(roleByIdWithUser);
        }
    }
}
