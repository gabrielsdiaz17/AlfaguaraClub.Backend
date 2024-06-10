using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.CreateNotificationTypeCommands
{
    public class CreateNotificationTypeCommandResponse: BaseResponse
    {
        public CreateNotificationTypeCommandResponse(): base()
        {
            
        }
        public int NotificationTypeId { get; set; }

    }
}
