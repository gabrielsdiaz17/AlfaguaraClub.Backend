using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class Session: AuditableEntity
    {
        [Key]
        public long SessionId { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
        [Column(TypeName = "text")]
        public string Token { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}
