using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserServices.QueryUserCommands
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserListVm>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserListQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserListVm>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersWithMembership();
            return _mapper.Map<List<UserListVm>>(users);
        }
    }
}
