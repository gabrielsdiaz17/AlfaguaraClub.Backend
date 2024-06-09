using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class Membership: AuditableEntity
    {
        [Key]
        public long MembershipId { get; set; }
        [MaxLength(50)]
        public string UniqueIdentifier { get; set; }
        public bool IsActive { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
