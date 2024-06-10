using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationServices.UpdateNotificationCommands
{
    public class UpdateNotificationCommand:IRequest
    {
        public long NotificationId { get; set; }
        public int NotificationTypeId { get; set; }
        public long UserId { get; set; }
        public DateTimeOffset NotificationDate { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool NotificationSent { get; set; }
        public bool IsActive { get; set; }

    }
}
