using AlfaguaraClub.Backend.Application.Contracts.Persistence;
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
    public class CreateNotificationTypeCommandHandler : IRequestHandler<CreateNotificationTypeCommand, int>
    {
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IMapper _mapper;
        public CreateNotificationTypeCommandHandler(INotificationTypeRepository notificationTypeRepository, IMapper mapper)
        {
            _notificationTypeRepository = notificationTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateNotificationTypeCommand request, CancellationToken cancellationToken)
        {
            var newNotificationType = _mapper.Map<NotificationType>(request);
            newNotificationType = await _notificationTypeRepository.AddAsync(newNotificationType);
            return newNotificationType.NotificationTypeId;
        }
    }
}
