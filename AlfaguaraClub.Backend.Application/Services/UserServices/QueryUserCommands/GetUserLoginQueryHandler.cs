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
    public class GetUserLoginQueryHandler : IRequestHandler<GetUserLoginQuery, UserListVm>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;
        public GetUserLoginQueryHandler(IUserRepository userRepository, IMembershipRepository membershipRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _membershipRepository = membershipRepository;
            _mapper = mapper;
        }

        public async Task<UserListVm> Handle(GetUserLoginQuery request, CancellationToken cancellationToken)
        {
            UserListVm response = new UserListVm();
            if (request.UniqueIdentifier != null && request.UniqueIdentifier != string.Empty)
            {
                var membership = await _membershipRepository.GetMembershipByIdentifier(request.UniqueIdentifier);
                if (membership == null) { }
                var usersMembership = membership.Users;
                var user = usersMembership.Where(user=> user.Password ==  request.Password).FirstOrDefault();
                response = _mapper.Map<UserListVm>(user);
            }
            else
            {
                var userToQuery = await _userRepository.GetUserLogin(request.Email, request.Password);
                response = _mapper.Map<UserListVm>(userToQuery);
            }
            return response;
        }
    }
}
