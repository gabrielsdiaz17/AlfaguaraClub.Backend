using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.QueryNotificationTypeCommands
{
    public class GetQueryIdentificationTypeListQuery:IRequest<List<NotificationTypeListVm>>
    {
    }
}
