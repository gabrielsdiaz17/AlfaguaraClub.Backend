using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationServices.QueryNotificationCommands
{
    public class GetNotificationQuery:IRequest<NotificationListVm>
    {
        public long NotificationId { get; set; }
    }
}
