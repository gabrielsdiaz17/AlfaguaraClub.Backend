using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class NotificationType: AuditableEntity
    {
        public int NotificationTypeId { get; set; }
        [MaxLength(500)]
        public string NotificationTypeDescription { get; set; }
    }
}
