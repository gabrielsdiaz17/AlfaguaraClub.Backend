using AlfaguaraClub.Backend.Application.Services.MembershipServices.QueryMembershipCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationServices.QueryNotificationCommands
{
    public class NotificationListVm
    {
        public long NotificationId { get; set; }
        public int NotificationTypeId { get; set; }
        public NotificationTypeDto NotificationType { get; set; }
        public long UserId { get; set; }
        public  UserDto User { get; set; }
        public DateTimeOffset NotificationDate { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool NotificationSent { get; set; }
        public bool IsActive { get; set; }

    }
}
