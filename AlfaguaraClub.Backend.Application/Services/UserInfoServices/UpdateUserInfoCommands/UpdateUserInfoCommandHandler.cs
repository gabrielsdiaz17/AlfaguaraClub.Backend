using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserInfoServices.UpdateUserInfoCommands
{
    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;
        public UpdateUserInfoCommandHandler(IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userInfoToUpdate = await _userInfoRepository.GetByIdAsync(request.UserInfoId);
            _mapper.Map(request,  userInfoToUpdate, typeof(UpdateUserInfoCommand), typeof(UserInfo));
            await _userInfoRepository.UpdateAsync(userInfoToUpdate);
        }
    }
}
