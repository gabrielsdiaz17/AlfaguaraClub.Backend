using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface INotificationRepository: IRepository<Notification>
    {

        Task<List<Notification>> GetNotifications();
        Task<List<Notification>> GetNotificationsByNotificationType(int typeNotification);
        Task <Notification> GetNotificationById(long id);
        Task<List<Notification>> GetNotificatipnByState(bool sent, DateTimeOffset dateNotification);
    }
}
