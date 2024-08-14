using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Exceptions;
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
    public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UpdateUserPasswordCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(request.UserId);
            if (userToUpdate == null)
                throw new NotFoundException(nameof(User), request.UserId);
            var validator = new UpdateUserPasswordCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count() > 0)
                throw new ValidationException(validationResult);
            byte[] bytesToEncode = System.Text.Encoding.UTF8.GetBytes(request.Password);
            string base64String = Convert.ToBase64String(bytesToEncode);
            request.Password = base64String;
            _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));
            await _userRepository.UpdateAsync(userToUpdate);
        }
    }
}
