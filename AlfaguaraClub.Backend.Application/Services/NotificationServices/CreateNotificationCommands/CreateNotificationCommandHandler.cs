using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Services.BookingServices.CreateBookingCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationServices.CreateNotificationCommands
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, CreateNotificationCommandResponse>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public CreateNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<CreateNotificationCommandResponse> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateNotificationCommandResponse();
            var newNotification = _mapper.Map<Notification>(request);
            var validator = new CreteNotificationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count >0) 
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                newNotification = await _notificationRepository.AddAsync(newNotification);
                response.NotificationId = newNotification.NotificationId;
                response.NotificationSent = newNotification.NotificationSent;
            }
            return response;
        }
    }
}
