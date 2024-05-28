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
    public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, List<RoleListVm>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public GetRoleListQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<List<RoleListVm>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var rolesWithUser = await _roleRepository.GetRolesWithUsers();
            return _mapper.Map<List<RoleListVm>>(rolesWithUser);
        }
    }
}
