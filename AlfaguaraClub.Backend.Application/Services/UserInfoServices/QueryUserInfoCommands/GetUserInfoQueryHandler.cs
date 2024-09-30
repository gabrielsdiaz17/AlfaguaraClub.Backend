using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserInfoServices.QueryUserInfoCommands
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserInfoVm>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;
        public GetUserInfoQueryHandler(IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
        }

        public async Task<UserInfoVm> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var userInfoData = await _userInfoRepository.GetRecentUserInfo(request.IdentificationNumber);
            return _mapper.Map<UserInfoVm>(userInfoData);   
        }
    }
}
