using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserServices.CreateUserCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user= _mapper.Map<User>(request);
            user = await _userRepository.AddAsync(user);
            return user.UserId;
        }
    }
}
