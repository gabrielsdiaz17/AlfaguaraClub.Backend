using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserInfoServices.CreateUserInfoCommands
{
    public class CreateUserInfoCommandHandler : IRequestHandler<CreateUserInfoCommand, CreateUserInfoCommandResponse>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;
        public CreateUserInfoCommandHandler(IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserInfoCommandResponse> Handle(CreateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var createUserInfoResponse = new CreateUserInfoCommandResponse();
            var userInfo = _mapper.Map<UserInfo>(request);
            userInfo.RecordDateTime = DateTime.Now;
            userInfo = await _userInfoRepository.AddAsync(userInfo);
            createUserInfoResponse.UserInfoId = userInfo.UserInfoId;
            return createUserInfoResponse;
        }
    }
}
