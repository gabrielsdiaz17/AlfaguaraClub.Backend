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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var createUserCommandResponse = new CreateUserCommandResponse();
            var user= _mapper.Map<User>(request);
            var validator = new CreateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count()>0)
            {
                createUserCommandResponse.Success = false;
                createUserCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    createUserCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createUserCommandResponse.Success)
            {
                byte[] bytesToEncode = System.Text.Encoding.UTF8.GetBytes(user.Password);
                string base64String = Convert.ToBase64String(bytesToEncode);
                user = await _userRepository.AddAsync(user);
                createUserCommandResponse.UserId = user.UserId;
            }
            
            return createUserCommandResponse;
        }
    }
}
