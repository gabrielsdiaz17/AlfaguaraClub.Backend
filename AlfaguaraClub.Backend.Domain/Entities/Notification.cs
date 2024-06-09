using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class Notification: AuditableEntity
    {
        public long NotificationId { get; set; }
        [ForeignKey("NotificationType")]
        public int NotificationTypeId { get; set; }
        public NotificationType NotificationType { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
        public DateTimeOffset NotificationDate { get; set; }
        [MaxLength(500)]
        public string Subject { get; set; }
        [Column(TypeName = "text")]
        public string Message { get; set; }
        public bool NotificationSent { get; set; }
        public bool IsActive { get; set; }

    }
}
