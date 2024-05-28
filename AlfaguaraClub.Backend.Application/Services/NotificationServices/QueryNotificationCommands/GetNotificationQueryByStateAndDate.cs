using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationServices.QueryNotificationCommands
{
    public class GetNotificationQueryByStateAndDate:IRequest<List<NotificationListVm>>
    {
        public bool NotificationSent { get; set; }
        public DateTimeOffset DateNotification { get; set; }
    }
}
