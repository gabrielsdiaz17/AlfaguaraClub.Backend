using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserServices.UpdateUserCommands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(request.UserId);
            if (userToUpdate == null) { }
            _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));
            await _userRepository.UpdateAsync(userToUpdate);
        }
    }
}
