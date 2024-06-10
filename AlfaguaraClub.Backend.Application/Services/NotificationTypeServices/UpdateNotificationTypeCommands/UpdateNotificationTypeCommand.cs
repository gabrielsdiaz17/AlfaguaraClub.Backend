using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.UpdateNotificationTypeCommands
{
    public class UpdateNotificationTypeCommand: IRequest
    {
        public int NotificationTypeId { get; set; }
        public string NotificationTypeDescription { get; set; }
        public bool IsActive { get; set; }


    }
}
