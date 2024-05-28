using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationServices.QueryNotificationCommands
{
    public class GetNotificationQueryByNotificationTypeQueryHandler : IRequestHandler<GetNotificationQueryByNotificationType, List<NotificationListVm>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public GetNotificationQueryByNotificationTypeQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<List<NotificationListVm>> Handle(GetNotificationQueryByNotificationType request, CancellationToken cancellationToken)
        {
            var notificationByNotificationType = await _notificationRepository.GetNotificationsByNotificationType(request.NotificationType);
            return _mapper.Map<List<NotificationListVm>>(notificationByNotificationType);   
        }
    }
}
