using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationServices.CreateNotificationCommands
{
    public class CreateNotificationCommandResponse:BaseResponse
    {
        public CreateNotificationCommandResponse():base()
        {
            
        }
        public long NotificationId { get; set; }
        public bool NotificationSent { get; set; }

    }
}
