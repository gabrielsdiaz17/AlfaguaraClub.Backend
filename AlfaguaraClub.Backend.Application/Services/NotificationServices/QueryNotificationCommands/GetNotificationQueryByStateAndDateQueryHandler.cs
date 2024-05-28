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
    public class GetNotificationQueryByStateAndDateQueryHandler : IRequestHandler<GetNotificationQueryByStateAndDate, List<NotificationListVm>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public GetNotificationQueryByStateAndDateQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<List<NotificationListVm>> Handle(GetNotificationQueryByStateAndDate request, CancellationToken cancellationToken)
        {
            var notificationByStates = await _notificationRepository.GetNotificatipnByState(request.NotificationSent, request.DateNotification);
            return _mapper.Map<List<NotificationListVm>>(notificationByStates);
        }
    }
}
