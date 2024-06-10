using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationServices.CreateNotificationCommands
{
    public class CreateNotificationCommand:IRequest<CreateNotificationCommandResponse>
    {
        public int NotificationTypeId { get; set; }
        public long UserId { get; set; }
        public DateTimeOffset NotificationDate { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool NotificationSent { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Notification User: {UserId}; Date: {NotificationDate}; Subject:{Subject}; Sent:{NotificationSent}";
        }
    }
}
