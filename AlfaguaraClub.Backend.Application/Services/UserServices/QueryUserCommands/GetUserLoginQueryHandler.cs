using AlfaguaraClub.Backend.Application.Contracts.Infraestructure;
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
    public class GetUserLoginQueryHandler : IRequestHandler<GetUserLoginQuery, GetUserLoginQueryCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;
        private readonly IJWTProvider _jwtProvider;
        public GetUserLoginQueryHandler(IUserRepository userRepository, IMembershipRepository membershipRepository, IMapper mapper,
            IJWTProvider jWTProvider)
        {
            _userRepository = userRepository;
            _membershipRepository = membershipRepository;
            _mapper = mapper;
            _jwtProvider = jWTProvider;
        }

        public async Task<GetUserLoginQueryCommandResponse> Handle(GetUserLoginQuery request, CancellationToken cancellationToken)
        {
            var response = new GetUserLoginQueryCommandResponse();
            UserListVm userLogin = new UserListVm();
            if (request.UniqueIdentifier != null && request.UniqueIdentifier != string.Empty)
            {
                var membership = await _membershipRepository.GetMembershipByIdentifier(request.UniqueIdentifier);
                var usersMembership = membership.Users;
                var user = usersMembership.Where(user=> user.Password ==  request.Password).FirstOrDefault();
                userLogin = _mapper.Map<UserListVm>(user);
            }
            else
            {
                var userToQuery = await _userRepository.GetUserLogin(request.Email, request.Password);
                userLogin = _mapper.Map<UserListVm>(userToQuery);
            }
            //Generate JWT
            response.User = userLogin;
            response.token = _jwtProvider.Generate(userLogin);
            return response;
        }
    }
}
