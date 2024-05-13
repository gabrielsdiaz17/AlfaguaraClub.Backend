using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class Membership: AuditableEntity
    {
        [Key]
        public long MembershipId { get; set; }
        public string UniqueIdentifier { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
