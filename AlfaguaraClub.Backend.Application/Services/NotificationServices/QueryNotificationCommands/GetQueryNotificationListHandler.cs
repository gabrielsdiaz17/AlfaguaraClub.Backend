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
    public class GetQueryNotificationListHandler : IRequestHandler<GetQueryNotificationList, List<NotificationListVm>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public GetQueryNotificationListHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<List<NotificationListVm>> Handle(GetQueryNotificationList request, CancellationToken cancellationToken)
        {
            var notifications = await _notificationRepository.GetNotifications();
            return _mapper.Map<List<NotificationListVm>>(notifications);
        }
    }
}
