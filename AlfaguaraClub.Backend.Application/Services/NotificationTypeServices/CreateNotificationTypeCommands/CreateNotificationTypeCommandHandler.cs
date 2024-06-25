using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Services.NotificationServices.CreateNotificationCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.CreateNotificationTypeCommands
{
    public class CreateNotificationTypeCommandHandler : IRequestHandler<CreateNotificationTypeCommand, CreateNotificationTypeCommandResponse>
    {
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IMapper _mapper;
        public CreateNotificationTypeCommandHandler(INotificationTypeRepository notificationTypeRepository, IMapper mapper)
        {
            _notificationTypeRepository = notificationTypeRepository;
            _mapper = mapper;
        }

        public async Task<CreateNotificationTypeCommandResponse> Handle(CreateNotificationTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateNotificationTypeCommandResponse();
            var newNotificationType = _mapper.Map<NotificationType>(request);
            var validator = new CreateNotificationTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Count >0 ) 
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach( var error in validationResult.Errors )
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if( response.Success )
            {
                newNotificationType = await _notificationTypeRepository.AddAsync(newNotificationType);
                response.NotificationTypeId = newNotificationType.NotificationTypeId;
            }            
            return response;
        }
    }
}
