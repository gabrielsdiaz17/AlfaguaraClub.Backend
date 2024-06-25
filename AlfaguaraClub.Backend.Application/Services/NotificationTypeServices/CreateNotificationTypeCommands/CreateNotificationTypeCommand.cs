using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.CreateNotificationTypeCommands
{
    public class CreateNotificationTypeCommand:IRequest<CreateNotificationTypeCommandResponse>
    {
        public string NotificationTypeDescription { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Notification Type{NotificationTypeDescription}";
        }
    }
}
