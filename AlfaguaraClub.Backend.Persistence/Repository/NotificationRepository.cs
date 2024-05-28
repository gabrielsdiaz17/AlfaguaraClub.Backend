﻿using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(IRepository<Notification> repository) : base(repository)
        {
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            var notification = await QueryNoTracking().Where(notification => notification.NotificationId == id)
                                                      .Include(notification=> notification.NotificationType)
                                                      .Include(notification=> notification.User)
                                                      .FirstOrDefaultAsync();
            return notification;

        }

        public async Task<List<Notification>> GetNotifications()
        {
            var notifications = await QueryNoTracking().Where(notification=> notification.IsActive)
                                                       .Include(notification=> notification.NotificationType)
                                                       .Include(notification=>notification.User)
                                                       .ToListAsync();
            return notifications;
        }

        public async Task<List<Notification>> GetNotificationsByNotificationType(long typeNotification)
        {
            var notificationByType = await QueryNoTracking().Where(notification => notification.IsActive && notification.NotificationTypeId == typeNotification)
                                                            .Include(notification => notification.NotificationType)
                                                            .Include(notification => notification.User)
                                                            .ToListAsync();
            return notificationByType;
        }

        public async Task<List<Notification>> GetNotificatipnByState(bool sent, DateTimeOffset dateNotification)
        {
            var notifications = await QueryNoTracking().Where(notification => notification.NotificationSent == sent && notification.NotificationDate == dateNotification).ToListAsync();
            return notifications;
        }
    }
}
