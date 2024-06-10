using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.QueryNotificationTypeCommands
{
    public class NotificationTypeListVm
    {
        public int NotificationTypeId { get; set; }
        public string NotificationTypeDescription { get; set; }
        public bool IsActive { get; set; }

    }
}
