using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationServices.UpdateNotificationCommands
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public UpdateNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notificationToUpdate = await _notificationRepository.GetByIdAsync(request.NotificationId);
            if (notificationToUpdate == null) { }
            _mapper.Map(request, notificationToUpdate, typeof(UpdateNotificationCommand), typeof(Notification));
            await _notificationRepository.UpdateAsync(notificationToUpdate);
        }
    }
}
