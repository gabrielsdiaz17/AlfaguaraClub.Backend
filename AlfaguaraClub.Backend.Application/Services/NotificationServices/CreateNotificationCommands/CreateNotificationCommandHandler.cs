using AlfaguaraClub.Backend.Application.Contracts.Persistence;
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
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, long>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public CreateNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var newNotification = _mapper.Map<Notification>(request);
            newNotification = await _notificationRepository.AddAsync(newNotification);
            return newNotification.NotificationId;
        }
    }
}
