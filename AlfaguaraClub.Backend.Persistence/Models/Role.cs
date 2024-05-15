using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class Role: AuditableEntity
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(200)]
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
