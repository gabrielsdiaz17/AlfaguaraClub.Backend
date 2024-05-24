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
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserListVm>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserListVm> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserWithMembership(request.UserId);
            if (user == null) { }
            return _mapper.Map<UserListVm>(user);
        }
    }
}
