using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class NotificationTypeRepository : BaseRepository<NotificationType>, INotificationTypeRepository
    {
        public NotificationTypeRepository(IRepository<NotificationType> repository) : base(repository)
        {
        }

        public async Task<List<NotificationType>> GetNotificationTypes()
        {
            var notificationtypes = await QueryNoTracking().Where(not=> not.IsActive).ToListAsync();
            return notificationtypes;
        }
    }
}
