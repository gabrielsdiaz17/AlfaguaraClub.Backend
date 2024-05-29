using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.UpdateNotificationTypeCommands
{
    public class UpdateNotificationTypeCommandHandler : IRequestHandler<UpdateNotificationTypeCommand>
    {
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IMapper _mapper;
        public UpdateNotificationTypeCommandHandler(INotificationTypeRepository notificationTypeRepository, IMapper mapper)
        {
            _notificationTypeRepository = notificationTypeRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateNotificationTypeCommand request, CancellationToken cancellationToken)
        {
            var notificationTypeToUpdate = await _notificationTypeRepository.GetByIdAsync(request.NotificationTypeId);
            if (notificationTypeToUpdate == null) { }
            _mapper.Map(request, notificationTypeToUpdate, typeof(UpdateNotificationTypeCommand), typeof(NotificationType));
            await _notificationTypeRepository.UpdateAsync(notificationTypeToUpdate);
        }
    }
}
